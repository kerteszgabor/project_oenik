using AutoMapper;
using project.Domain.DTO.TestResults;
using project.Domain.Interfaces;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Domain.Helpers.ClassReportBuilder;
using project.Service.Interfaces;

namespace project.Service.Interfaces
{
    public class TestManagerService : ITestManagerService
    {
        private readonly ITestsService testsService;
        private readonly IClassReportBuilder builder;
        private readonly IQuestionService questionService;
        private readonly ICourseService courseService;
        private readonly ITestResultRepository testResultRepository;
        private readonly ICourseRepository courseRepository;
        public TestManagerService(ITestsService testsService, IClassReportBuilder builder, IQuestionService questionService, ICourseService courseService, ITestResultRepository testResultRepository, ICourseRepository courseRepository)
        {
            this.testsService = testsService;
            this.builder = builder;
            this.questionService = questionService;
            this.courseService = courseService;
            this.testResultRepository = testResultRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<bool> SubmitAnswerToTestResult(AnswerDTO answerDTO)
        {
            var model = await CreateModelFromDTO(answerDTO);
            var testresult = await GetExistingTestResult(answerDTO.TestID, answerDTO.User);

            if (await testResultRepository.GetAsync(testresult?.ID) != null)
            {
                if (IsInTime(testresult.StartTime, testresult.Test.AllowedTakeLength))
                {
                    testresult.Answers.Add(model);
                    return await testResultRepository.UpdateAsync(testresult);
                }
                else if (!testresult.IsClosed)
                {
                    CorrectTestResult(testresult);
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> ToogleTestStatus(string testID, string courseID)
        {
            Test relatedTest = await testsService.Get(testID);
            Course relatedCourse = await courseService.Get(courseID);
            var connectingEntity = relatedCourse.CourseTests.FirstOrDefault(x => x.TestID == relatedTest.ID);

            if (connectingEntity != null)
            {
                connectingEntity.IsOpen = !connectingEntity.IsOpen;
                await courseRepository.UpdateAsync(relatedCourse);
                return true;
            }

            return false;
        }

        public async Task<bool> StartTestCompletion(TestStartStopDTO startDTO)
        {
            Test relatedTest = await testsService.Get(startDTO.TestID);
            Course relatedCourse = await courseService.Get(startDTO.CourseID);
            var connectingEntity = relatedTest.CourseTests.FirstOrDefault(x => x.CourseID == relatedCourse.ID);

            if (connectingEntity.IsOpen && ValidateIPAddress(connectingEntity.AllowedIPSubnet, startDTO.IPAddress))
            {
                if (relatedCourse.UserCourses.Any(x => x.User == startDTO.User) && (await GetExistingTestResult(startDTO.TestID, startDTO.User) == null))
                {
                    TestResult newResult = InitNewTestResult(relatedTest, relatedCourse, startDTO.User);
                    return await testResultRepository.CreateAsync(newResult);
                }
            }

            return false;
        }

        public async Task EndTestCompletion(TestStartStopDTO stopDTO)
        {
            CorrectTestResult(await GetExistingTestResult(stopDTO.TestID, stopDTO.User));
        }

        private async Task<Answer> CreateModelFromDTO(AnswerDTO answerDTO)
        {
            var model = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnswerDTO, Answer>();
                cfg.AddGlobalIgnore("User");
            })
                .CreateMapper()
                .Map<AnswerDTO, Answer>(answerDTO);

            model.ID = Guid.NewGuid().ToString();
            model.Question = await questionService.Get(answerDTO.QuestionID);

            return model;
        }

        private bool IsInTime(DateTime startTime, TimeSpan timeAllowed)
        {
            return startTime + timeAllowed > DateTime.Now;
        }

        private void CorrectTestResult(TestResult testResult)
        {
            testResult.PointResult = 0;
            testResult.IsClosed = true;
            testResult.FinishTime = DateTime.Now;

            var normalQuestions = testResult.Answers.Where(x => x.Question is not ProgrammingQuestion);
            var programmingQuestions = testResult.Answers.Except(normalQuestions);

            foreach (var item in normalQuestions)
            {
                if (!item.Question.CorrectManually)
                {
                    if (item.AnswerText == item.Question.CorrectAnswer)
                    {
                        testResult.PointResult += item.Question.MaxPoints;
                    }
                }
            }

            CorrectProgrammingQuestions(programmingQuestions, testResult);

            if (!testResult.Answers.Any(x => x.CorrectManually))
            {
                testResult.IsCorrectionFinished = true;
            }

            testResultRepository.UpdateAsync(testResult);
        }

        private void CorrectProgrammingQuestions(IEnumerable<Answer> answers, TestResult testResult)
        {
            List<ClassReport> reports = new List<ClassReport>();

            foreach (var item in answers)
            {
                var question = item.Question as ProgrammingQuestion;
                var buildObject = builder.GetReportOf(item.AnswerText);
                foreach (var method in question.Methods)
                {
                    ICanRequireCompilation methodObject = null;
                    methodObject = buildObject.WithMethod(method);
                    if (method.RequireCompilation)
                    {
                        ICanCompile compileObject = methodObject.AlsoCompile();
                        if (method.Parameters != null)
                        {
                            object[] parameters = new object[method.Parameters.Length];
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                parameters[i] = (method.Parameters[i]);
                            }
                            compileObject.WithParameters(parameters);
                        }
                        if (method.ExpectedStringOutput != null)
                        {
                            compileObject = compileObject.SetExpectedStringOutput(method.ExpectedStringOutput);
                        }
                        if (method.ExpectedValue != null)
                        {
                            compileObject = compileObject.SetExpectedValue(method.ExpectedValue);
                        }
                    }
                }
                reports.Add(buildObject.Build());
            }

            testResult.ProgQuestionReports = new List<ClassReport>();
            foreach (var item in reports)
            {
                if (!item.HadCompilationError)
                {
                    int points = item.ValidMethodsByExistence.Count
                    + item.ValidMethodsByOutput.Count
                    + item.ValidMethodsByParameters.Count
                    + item.ValidMethodsByReturnType.Count
                    - item.MissingMethods.Count
                    - item.MismatchingOutputMethods.Count
                    - item.MismatchingParametersMethods.Count
                    - item.MismatchingReturnTypeMethods.Count;

                    testResult.PointResult += Math.Max(points, 0);
                }

                testResult.ProgQuestionReports.Add(item);
            }
        }

        private TestResult InitNewTestResult(Test test, Course course, User user)
        {
            return new TestResult()
            {
                ID = Guid.NewGuid().ToString(),
                Test = test,
                User = user,
                Course = course,
                Answers = new List<Answer>(),
                StartTime = DateTime.Now,
                IsCorrectionFinished = false,
                FinishTime = DateTime.MinValue
            };
        }

        private async Task<TestResult> GetExistingTestResult(string testID, User user)
        {
            return await testResultRepository.GetAllAsync()
                .FirstOrDefaultAsync(x => x.User == user && x.Test.ID == testID);
        }

        private bool ValidateIPAddress(string expectedIP, string actualIP)
        {
            expectedIP = expectedIP.ToLower();
            actualIP = actualIP.ToLower();

            if (string.IsNullOrEmpty(expectedIP))
            {
                return true;
            }
            else if (expectedIP == "0.0.0.0" && actualIP == "::1")
            {
                return true;
            }

            if (expectedIP.Contains('x'))
            {
                int idxOfx = expectedIP.IndexOf('x');
                return actualIP.Substring(0, idxOfx) == expectedIP.Substring(0, idxOfx);
            }
            else
            {
                return expectedIP == actualIP;
            }
        }
    }
}
