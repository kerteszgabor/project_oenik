using project.Domain.DTO.Tests;
using project.Domain.Interfaces;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.Services
{
    public class LabelService : ILabelService
    {
        private readonly IQuestionRepository questionRepository;

        public LabelService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public async Task<bool> Delete(string uid)
        {
            return await questionRepository.DeleteLabelAsync(uid);
        }

        public async IAsyncEnumerable<QuestionLabel> List()
        {
            await foreach (var item in questionRepository.GetAllLabelsAsync())
            {
                yield return item;
            }
        }

        public async Task<bool> Insert(LabelDTO newLabel)
        {
            if (newLabel != null)
            {
                QuestionLabel labelToAdd = new QuestionLabel()
                {
                    LabelText = newLabel.LabelText,
                    Question = await questionRepository.GetAsync(newLabel.QuestionID)
                };

                return await questionRepository.AddLabelAsync(labelToAdd);
            }
            else
            {
                return false;
            }
        }

        public async IAsyncEnumerable<Question> GetQuestionsWithLabel(string labelText)
        {
            var questions = List()
                .Where(x => x.LabelText == labelText)
                .Select(x => x.Question);

            await foreach (var item in questions)
            {
                yield return item;
            }
        }
    }
}
