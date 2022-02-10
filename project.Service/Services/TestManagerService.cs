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
        public TestManagerService(ITestsService testsService, IClassReportBuilder builder, IQuestionService questionService, ICourseService courseService, ITestResultRepository testResultRepository)
        {
            this.testsService = testsService;
            this.builder = builder;
            this.questionService = questionService;
            this.courseService = courseService;
            this.testResultRepository = testResultRepository;
        }

        public async IAsyncEnumerable<TestResult> GetAllResults()
        {
            await foreach (var item in testResultRepository.GetAllAsync())
            {
                yield return item;
            }
        }

        public async Task<bool> SubmitAnswerToTestResult(AnswerDTO answerDTO)
        {
            var model = await CreateModelFromDTO(answerDTO);

            var testresult = await testResultRepository.GetAllAsync()
                .FirstOrDefaultAsync(x => x.User == answerDTO.User && x.Test.ID == answerDTO.TestID);

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
                    return false; // TODO throw exception
                }
            }

            return false;
        }

        public async Task<bool> StartTestCompletion(TestStartDTO startDTO)
        {
            Test relatedTest = await testsService.Get(startDTO.TestID);
            Course relatedCourse = await courseService.Get(startDTO.CourseID);
            TestResult newResult = InitNewTestResult(relatedTest, relatedCourse, startDTO.User);
            return await testResultRepository.CreateAsync(newResult);
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
            if (startTime + timeAllowed < DateTime.Now)
            {
                return false;
            }

            return true;
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
                    if (method.ParameterList != null && method.ExpectedReturnType != null)
                    {
                        methodObject = buildObject.WithMethod(method.MethodName, method.ParameterList, method.ExpectedReturnType);
                    }
                    else if (method.ParameterList != null)
                    {
                        methodObject = buildObject.WithMethod(method.MethodName, method.ParameterList);
                    }
                    else if (method.ExpectedReturnType != null)
                    {
                        methodObject = buildObject.WithMethod(method.MethodName, method.ExpectedReturnType);
                    }
                    else
                    {
                        methodObject = buildObject.WithMethod(method.MethodName);
                    }
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
    }
}
