using project.Domain.DTO.Tests;
using project.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Client.Services
{
    public class QuestionsService : ServiceBase
    {
        public QuestionsService(string url)
        {
            BaseURL = url;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Question>>($"{BaseURL}/questions");
            return response.Result;
        }

        public async Task<IEnumerable<Question>> GetOwnQuestionsAsync()
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Question>>($"{BaseURL}/questions/OwnQuestions");
            return response.Result;
        }

        public async Task<Question> GetQuestionAsync(string id)
        {
            var response = await Client.GetProtectedAsync<Question>($"{BaseURL}/questions/{id}");
            return response.Result;
        }

        public async Task<bool> DeleteQuestionAsync(string id)
        {
            var response = await Client.DeleteProtectedAsync<Question>($"{BaseURL}/questions/{id}");
            return response.IsSucceded;
        }

        public async Task<bool> AddQuestionAsync(QuestionDTO questionDTO)
        {
            var response = await Client.PostProtectedAsync<Question>($"{BaseURL}/questions/", questionDTO);
            if (response.IsSucceded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Question> UpdateQuestionAsync(string id)
        {
            var response = await Client.GetProtectedAsync<Question>($"{BaseURL}/questions/{id}");
            return response.Result;
        }

        public async Task<IEnumerable<Question>> GetLabelledQuestions(string label)
        {
            var response = await Client.GetProtectedAsync<IEnumerable<Question>>($"{BaseURL}/labels/getLabelledQuestions?labelText={label}");
            return response.Result;
        }

        public async Task<bool> AddLabelsToQuestion(List<string> labels, string questionID)
        {
            bool result = true;
            foreach (var label in labels)
            {
                LabelDTO model = new LabelDTO()
                {
                    LabelText = label,
                    QuestionID = questionID
                };
                if (result)
                {
                    result = (await Client.PostProtectedAsync<LabelDTO>($"{BaseURL}/labels/", model)).IsSucceded;
                } 
            }
            return result;
        }

        public async Task<bool> AddQuestionToTest(string questionID, string testID)
        {
            var response = await Client.GetProtectedAsync<bool>($"{BaseURL}/tests/addQuestionToTest?questionID={questionID}&testID={testID}");
            if (response.IsSucceded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
