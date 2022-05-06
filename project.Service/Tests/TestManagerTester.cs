using Moq;
using NUnit.Framework;
using project.Domain.DTO.TestResults;
using project.Domain.Helpers.ClassReportBuilder;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Domain.Models.DBConnections;
using project.Service.Interfaces;
using project.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Tests
{
    internal class TestManagerTester
    {

        private IClassReportBuilder builder;
        private Mock<ITestsService> _testServiceMock;
        private Mock<IQuestionService> _questionServiceMock;
        private Mock<ICourseService> _courseServiceMock;
        private Mock<ITestResultRepository> _testResultRepoMock;
        private Mock<ICourseRepository> _courseRepoMock;
        private TestManagerService testManagerService;
        User user;

        [SetUp]
        public void Setup()
        {
            builder = new ClassReportBuilder();
            _testServiceMock = new Mock<ITestsService>();
            _questionServiceMock = new Mock<IQuestionService>();
            _courseServiceMock = new Mock<ICourseService>();
            _courseRepoMock = new Mock<ICourseRepository>();
            _testResultRepoMock = new Mock<ITestResultRepository>();

            _testServiceMock.SetupAllProperties();
            _questionServiceMock.SetupAllProperties();
            _courseServiceMock.SetupAllProperties();
            _courseRepoMock.SetupAllProperties();
            _testResultRepoMock.SetupAllProperties();

            user = new User() { Id = "user" };

            testManagerService = new TestManagerService(
                _testServiceMock.Object, builder, 
                _questionServiceMock.Object, _courseServiceMock.Object, 
                _testResultRepoMock.Object, _courseRepoMock.Object);
        }

        [Test]
        public async Task SubmitAnswerTest()
        {
            // Arrange

            var closedResult = new TestResult()
            {
                ID = "closedResult",
                StartTime = DateTime.Now,
                Test = new Test() { AllowedTakeLength = TimeSpan.FromDays(365), ID = "closedResult" },
                IsClosed = true,
                User = user,
                PointResult = -1,
                Answers = new List<Answer>(),
                ProgQuestionReports = new List<ClassReport>()
            };

            var outOfTimeResult = new TestResult()
            {
                ID = "outOfTimeResult",
                StartTime = DateTime.Parse("1970.01.01"),
                Test = new Test() { AllowedTakeLength = TimeSpan.FromSeconds(1), ID = "outOfTimeResult" },
                User = user,
                Answers = new List<Answer>(),
                ProgQuestionReports = new List<ClassReport>()
            };

            var openResult = new TestResult()
            {
                ID = "openResult",
                StartTime = DateTime.Now,
                Test = new Test() { AllowedTakeLength = TimeSpan.FromDays(365), ID = "openResult" },
                User = user,
                Answers = new List<Answer>(),
                ProgQuestionReports = new List<ClassReport>()
            };

            _testResultRepoMock.Setup(x => x.GetAsync("closedResult"))
                .ReturnsAsync(closedResult);

            _testResultRepoMock.Setup(x => x.GetAsync("outOfTimeResult"))
                .ReturnsAsync(outOfTimeResult);

            _testResultRepoMock.Setup(x => x.GetAsync("openResult"))
                .ReturnsAsync(openResult);

            _testResultRepoMock.Setup(x => x.UpdateAsync(It.IsAny<TestResult>())).ReturnsAsync(true);

            var resultList = new List<TestResult>();
            resultList.Add(closedResult);
            resultList.Add(outOfTimeResult);
            resultList.Add(openResult);

            _testResultRepoMock.Setup(x => x.GetAllAsync())
                .Returns(resultList.ToAsyncEnumerable());

            // Act, Assert
            
            Assert.IsFalse(await testManagerService.SubmitAnswerToTestResult(new AnswerDTO { TestID = "closedResult", User = user }));
            Assert.IsFalse(await testManagerService.SubmitAnswerToTestResult(new AnswerDTO { TestID = "outOfTimeResult", User = user }));

            _testResultRepoMock.Verify(x => x.UpdateAsync(It.IsAny<TestResult>()), Times.Once);
            Assert.Zero((_testResultRepoMock.Invocations.LastOrDefault().Arguments.FirstOrDefault() as TestResult).PointResult);

            Assert.IsTrue(await testManagerService.SubmitAnswerToTestResult(new AnswerDTO { TestID = "openResult", User = user }));
            _testResultRepoMock.Verify(x => x.UpdateAsync(It.IsAny<TestResult>()), Times.Exactly(2));
            Assert.NotZero((_testResultRepoMock.Invocations.LastOrDefault().Arguments.FirstOrDefault() as TestResult).Answers.Count);
        }

        [Test]
        public async Task ToogleTestStatusTest()
        {
            // Arrange
            Course course = new Course()
            {
                ID = "courseID",
                CourseTests = new List<CourseTest> { new CourseTest() { IsOpen = false, TestID = "testID" } }
            };

            _courseRepoMock.Setup(x => x.UpdateAsync(It.IsAny<Course>())).ReturnsAsync(true);
            _courseRepoMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(course);

            // Act, Assert
            Assert.IsTrue(await testManagerService.ToogleTestStatus("testID", "courseID"));
            Assert.IsTrue((_courseRepoMock.Invocations[1].Arguments[0] as Course).CourseTests.FirstOrDefault().IsOpen);
            _courseRepoMock.Verify(x => x.UpdateAsync(It.IsAny<Course>()), Times.Once);

            Assert.IsTrue(await testManagerService.ToogleTestStatus("testID", "courseID"));
            Assert.IsFalse((_courseRepoMock.Invocations[3].Arguments[0] as Course).CourseTests.FirstOrDefault().IsOpen);
            _courseRepoMock.Verify(x => x.UpdateAsync(It.IsAny<Course>()), Times.Exactly(2));

            Assert.IsFalse(await testManagerService.ToogleTestStatus("error", "error"));
        }

        [Test]
        public async Task StartStopTestCompletionTest()
        {
            // Arrange
            Course course = new Course()
            {
                ID = "courseID",
                UserCourses = new List<UserCourse> { new UserCourse() { User = user } }
            };

            Test test = new Test() 
            { 
                ID = "testID",
                CourseTests = new List<CourseTest> { new CourseTest() { IsOpen = true, TestID = "testID", AllowedIPSubnet = "0.0.0.0", CourseID = course.ID } },
            };

            TestStartStopDTO dto = new TestStartStopDTO()
            {
                CourseID = course.ID,
                IPAddress = "192.168.10.14",
                TestID = test.ID,
                User = user
            };

            _testResultRepoMock.Setup(x => x.CreateAsync(It.IsAny<TestResult>())).ReturnsAsync(true);
            _testResultRepoMock.Setup(x => x.UpdateAsync(It.IsAny<TestResult>())).ReturnsAsync(true);
            _courseRepoMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(course);
            _testServiceMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(test);

            // Act, Assert

            Assert.IsTrue(await testManagerService.StartTestCompletion(dto));
            var testResult = _testResultRepoMock.Invocations[1].Arguments[0] as TestResult;
            Assert.IsFalse(testResult.IsClosed);
            Assert.AreEqual(user, testResult.User);
            Assert.AreEqual(test, testResult.Test);
            Assert.Zero(testResult.PointResult);
            _testResultRepoMock.Verify(x => x.CreateAsync(It.IsAny<TestResult>()), Times.Once);

            _testResultRepoMock.Setup(x => x.GetAllAsync()).Returns(new List<TestResult>() { testResult}.ToAsyncEnumerable());

            await testManagerService.EndTestCompletion(dto);
            testResult = _testResultRepoMock.Invocations[3].Arguments[0] as TestResult;
            Assert.IsTrue(testResult.IsClosed);
            Assert.IsTrue(testResult.IsCorrectionFinished);
        }
    }
}
