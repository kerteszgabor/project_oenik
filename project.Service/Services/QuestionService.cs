using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using project.Domain.DTO.Tests;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IUserService userService;
        public QuestionService(IQuestionRepository questionRepository, IUserService userService)
        {
            this.questionRepository = questionRepository;
            this.userService = userService;
        }

        public async Task<bool> Delete(string uid)
        {
            return await questionRepository.DeleteAsync(uid);
        }

        public async Task<Question> Get(string uid)
        {
            return await questionRepository.GetAsync(uid);
        }

        public async IAsyncEnumerable<Question> List()
        {
            await foreach (var item in questionRepository.GetAllAsync())
                yield return item;
        }


        public async Task<bool> Insert(QuestionDTO newQuestion)
        {

            if (newQuestion != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TestDTO, Test>();
                    cfg.AddGlobalIgnore("CreatedBy");
                });
                IMapper iMapper = config.CreateMapper();

                var model = iMapper.Map<QuestionDTO, Question>(newQuestion);
                model.CreatedBy = await userService.GetUserByName(newQuestion.CreatedBy);
                model.CreationTime = DateTime.Now;

                return await questionRepository.CreateAsync(model);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(string uid, JsonPatchDocument<Question> patch)
        {
            if (patch != null)
            {
                var question = await questionRepository.GetAsync(uid);
                patch.ApplyTo(question);
                var result = await questionRepository.UpdateAsync(question);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
