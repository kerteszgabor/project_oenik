using AutoMapper;
using project.Domain.DTO.TestResults;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.Services
{
    public class TestManagerService : ITestManagerService
    {
        private readonly ITestsService testsService;
        private readonly IQuestionService questionService;
        private readonly ITestResultRepository testResultRepository;
        public TestManagerService(ITestsService testsService, IQuestionService questionService, ITestResultRepository testResultRepository)
        {
            this.testsService = testsService;
            this.questionService = questionService;
            this.testResultRepository = testResultRepository;
        }

        public async IAsyncEnumerable<TestResult> GetAllResults()
        {
            await foreach (var item in testResultRepository.GetAllAsync())
            {
                yield return item;
            }
        }

        public async Task<TestResult> Get(string uid)
        {
            return await testResultRepository.GetAsync(uid);
        }

        public IAsyncEnumerable<TestResult> GetTestsOfCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<TestResult> GetTestsOfUser(User user)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<TestResult> GetTestsOfUserInCourse(User user, Course course)
        {
            throw new NotImplementedException();
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
            //TODO change null when course service is implemented
            TestResult newResult = InitNewTestResult(relatedTest, null, startDTO.User);
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

            foreach (var item in testResult.Answers)
            {
                if (!item.Question.CorrectManually && !(item.Question is ProgrammingQuestion))
                {
                    if (item.AnswerText == item.Question.CorrectAnswer)
                    {
                        testResult.PointResult += item.Question.MaxPoints;
                    }
                }
            }

            CorrectProgrammingQuestions(testResult.Answers);

            if (!testResult.Answers.Any(x => x.CorrectManually))
            {
                testResult.IsCorrectionFinished = true;
            }

            testResultRepository.UpdateAsync(testResult);
        }

        private void CorrectProgrammingQuestions(List<Answer> answers)
        {
            throw new NotImplementedException();
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
