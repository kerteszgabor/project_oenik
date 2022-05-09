using Moq;
using NUnit.Framework;
using project.Domain.DTO.ClassReport;
using project.Domain.DTO.Tests;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Service.Interfaces;
using project.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Tests
{
    internal class QuestionServiceTester
    {
        private Mock<ILabelService> _labelServiceMock;
        private Mock<IUserService> _userServiceMock;
        private Mock<IQuestionRepository> _questionRepositoryMock;
        private Mock<IProgrammingQuestionRepository> _programmingQuestionRepositoryMock;
        private QuestionService questionService;
        User user;

        [SetUp]
        public void Setup()
        {
            _labelServiceMock = new Mock<ILabelService>();
            _userServiceMock = new Mock<IUserService>();
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _programmingQuestionRepositoryMock = new Mock<IProgrammingQuestionRepository>();

            user = new User() { Id = "user" };

            questionService = new QuestionService(
                _questionRepositoryMock.Object, _programmingQuestionRepositoryMock.Object, 
                _userServiceMock.Object, _labelServiceMock.Object);
        }

        [Test]
        public async Task InsertNormalQuestionTest()
        {
            // Arrange

            var questionDTO = new QuestionDTO()
            {
                Text = "test question text, should the first 3 be the title",
                CreatedBy = user,
                QuestionType = QuestionType.Text.ToString(),
                CorrectAnswer = "correct answer",
                MaxPoints = 5,
                Labels = new List<LabelDTO>() { new LabelDTO() { LabelText = "label"} }
            };

            Question question = new Question()
            {
                ID = "label should be added to this",
                Text = "test question text, should the first 3 be the title",
                CreatedBy = user,
                QuestionType = QuestionType.Text,
                CorrectAnswer = "correct answer",
                MaxPoints = 5,
            };

            _questionRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Question>())).ReturnsAsync(true);
            _questionRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Question>())).ReturnsAsync(true);
            _questionRepositoryMock.Setup(x => x.GetAllAsync()).Returns(new List<Question>() { question }.ToAsyncEnumerable());
            _programmingQuestionRepositoryMock.Setup(x => x.GetAllAsync()).Returns(new List<ProgrammingQuestion>().ToAsyncEnumerable);

            // Act, Assert

            Assert.IsTrue(await questionService.Insert(questionDTO));

            _questionRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Question>()), Times.Once);
            var createdQuestion = _questionRepositoryMock.Invocations.FirstOrDefault().Arguments.FirstOrDefault() as Question;
            Assert.AreEqual(5, createdQuestion.MaxPoints);
            Assert.AreEqual("test question text,", createdQuestion.Title);
            Assert.AreEqual(user, createdQuestion.CreatedBy);

            var addedLabel = (_labelServiceMock.Invocations.FirstOrDefault().Arguments.FirstOrDefault()) as LabelDTO;
            Assert.AreEqual(question.ID, addedLabel.QuestionID);
        }

        [Test]
        public async Task InsertProgrammingQuestion()
        {
            // Arrange

            var parameters = new ParamList();
            parameters.Add(new MyTuple("string", "test"));
            string parameter = "given parameter";
            List<User> userList = new List<User>();
            userList.Add(user);

            var method = new MethodInfoData()
            {
                ExpectedReturnType = "int",
                ExpectedValue = "",
                MethodName = "TestMethod",
                ParameterList = parameters,
                Parameters = new object[] { parameter, 5, 3.4, true, 'x', new int[] {1, 2, 3 }, userList },
                RequireCompilation = true
            };

            var questionDTO = new ProgQuestionDTO()
            {
                Text = "test question text, should the first 3 be the title",
                CreatedBy = user,
                QuestionType = QuestionType.Text.ToString(),
                CorrectAnswer = "correct answer",
                MaxPoints = 5,
                Labels = new List<LabelDTO>() { new LabelDTO() { LabelText = "label" } },
                Methods = new List<MethodInfoData> { method }
            };

            ProgrammingQuestion question = new ProgrammingQuestion()
            {
                ID = "label should be added to this",
                Text = "test question text, should the first 3 be the title",
                CreatedBy = user,
                QuestionType = QuestionType.Text,
                CorrectAnswer = "correct answer",
                MaxPoints = 5,
                Methods = new List<MethodInfoData> { method }
            };

            _programmingQuestionRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<ProgrammingQuestion>())).ReturnsAsync(true);
            _programmingQuestionRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<ProgrammingQuestion>())).ReturnsAsync(true);
            _programmingQuestionRepositoryMock.Setup(x => x.GetAllAsync()).Returns(new List<ProgrammingQuestion>() { question }.ToAsyncEnumerable());
            _questionRepositoryMock.Setup(x => x.GetAllAsync()).Returns(new List<Question>().ToAsyncEnumerable());

            // Act, Assert

            Assert.IsTrue(await questionService.Insert(questionDTO));

            _programmingQuestionRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<ProgrammingQuestion>()), Times.Once);
            var createdQuestion = _programmingQuestionRepositoryMock.Invocations.FirstOrDefault().Arguments.FirstOrDefault() as ProgrammingQuestion;
            Assert.AreEqual(5, createdQuestion.MaxPoints);
            Assert.AreEqual("test question text,", createdQuestion.Title);
            Assert.AreEqual(user, createdQuestion.CreatedBy);
            Assert.AreEqual(1, createdQuestion.Methods.Count);
            Assert.AreEqual(method, createdQuestion.Methods.FirstOrDefault());
            Assert.AreEqual("given parameter", (createdQuestion.Methods.FirstOrDefault().Parameters[0] as string));
            Assert.AreEqual(5, (int)createdQuestion.Methods.FirstOrDefault().Parameters[1]);
            Assert.AreEqual(3.4, (double)createdQuestion.Methods.FirstOrDefault().Parameters[2]);
            Assert.AreEqual(true, (bool)createdQuestion.Methods.FirstOrDefault().Parameters[3]);
            Assert.AreEqual('x', (char)createdQuestion.Methods.FirstOrDefault().Parameters[4]);
            Assert.AreEqual(new int[] {1,2,3}, createdQuestion.Methods.FirstOrDefault().Parameters[5]);
            Assert.AreEqual(userList, createdQuestion.Methods.FirstOrDefault().Parameters[6]);

            var addedLabel = (_labelServiceMock.Invocations.FirstOrDefault().Arguments.FirstOrDefault()) as LabelDTO;
            Assert.AreEqual(question.ID, addedLabel.QuestionID);
        }
    }
}
