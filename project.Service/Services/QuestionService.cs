using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using project.Domain.DTO.Tests;
using project.Domain.Interfaces;
using project.Domain.Models;
using project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace project.Domain.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IProgrammingQuestionRepository progQuestionRepository;
        private readonly IUserService userService;
        public QuestionService(IQuestionRepository questionRepository, IProgrammingQuestionRepository progQuestionRepository, IUserService userService)
        {
            this.questionRepository = questionRepository;
            this.progQuestionRepository = progQuestionRepository;
            this.userService = userService;
        }

        public async Task<bool> Delete(string uid)
        {
            return await questionRepository.DeleteAsync(uid);
        }

        public async Task<Question> Get(string uid)
        {
            var normalQuestion = await questionRepository.GetAsync(uid);
            if (normalQuestion != null)
            {
                return normalQuestion;
            }
            else
            {
                return await progQuestionRepository.GetAsync(uid);
            }
        }

        public async IAsyncEnumerable<Question> List()
        {
            await foreach (var item in questionRepository.GetAllAsync())
            {
                yield return item;
            }

            await foreach (var item in progQuestionRepository.GetAllAsync())
            {
                yield return item;
            }
        }

        public async Task<bool> Insert(QuestionDTO newQuestion) 
        {
            if (newQuestion.GetType() == typeof(QuestionDTO))
            {
                return await InsertNormalQuestion(newQuestion);
            }
            else
            {
                return await InsertProgQuestion((ProgQuestionDTO)newQuestion);
            }
        }

        private async Task<bool> InsertNormalQuestion(QuestionDTO newQuestion)
        {
            if (newQuestion != null)
            {
                var model = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<QuestionDTO, Question>();
                    cfg.AddGlobalIgnore("CreatedBy");
                })
                    .CreateMapper()
                    .Map<QuestionDTO, Question>(newQuestion);

                model.CreatedBy = await userService.GetUserByName(newQuestion.CreatedBy);
                model.CreationTime = DateTime.Now;

                return await questionRepository.CreateAsync(model);
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> InsertProgQuestion(ProgQuestionDTO newQuestion)
        {
            if (newQuestion != null)
            {
                var model = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProgQuestionDTO, ProgrammingQuestion>();
                    cfg.AddGlobalIgnore("CreatedBy");
                })
                    .CreateMapper()
                    .Map<ProgQuestionDTO, ProgrammingQuestion>(newQuestion);

                model.CreatedBy = await userService.GetUserByName(newQuestion.CreatedBy);
                model.CreationTime = DateTime.Now;

                for (int i = 0; i < newQuestion.Methods.Count; i++)
                {
                    var method = newQuestion.Methods[i];
                    if (method.Parameters != null)
                    {
                        object[] parameters = new object[method.Parameters.Length];
                        for (int j = 0; j < parameters.Length; j++)
                        {
                            var node = (JsonElement)method.Parameters[i];
                            if (node.ValueKind == JsonValueKind.Number)
                            {
                                model.Methods.ToArray()[i].Parameters[j] = JsonConvert.DeserializeObject(method.Parameters[i].ToString());
                            }
                            else
                            {
                                model.Methods.ToArray()[i].Parameters[j] = node.GetString();
                            }

                        }
                    }
                }

                return await progQuestionRepository.CreateAsync(model);
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
