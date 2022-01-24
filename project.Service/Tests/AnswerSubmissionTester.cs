using Moq;
using NUnit.Framework;
using project.Domain.Interfaces;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Domain.Tests
{
    [TestFixture]
    class AnswerSubmissionTester
    {
        private Mock<IAnswerRepository> _answerRepo;
        private List<Answer> answers;

        [SetUp]
        void Setup()
        {
            _answerRepo = new Mock<IAnswerRepository>();
            //_answerRepo.Setup(x => x.GetAll()).Returns()

            //answers = new List<Answer>()
            //{
            //    new Answer(){ }
            //}
        }
         
    }
}
