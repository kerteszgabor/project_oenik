﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using project.Domain.DTO.Tests;
using project.Domain.Interfaces;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
//using Newtonsoft.Json;
using project.Service.Interfaces;
using System.Text.Json.Nodes;

namespace project.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IProgrammingQuestionRepository progQuestionRepository;
        private readonly IUserService userService;
        private ILabelService labelService;

        public QuestionService(IQuestionRepository questionRepository, IProgrammingQuestionRepository progQuestionRepository, IUserService userService, ILabelService labelService)
        {
            this.questionRepository = questionRepository;
            this.progQuestionRepository = progQuestionRepository;
            this.userService = userService;
            this.labelService = labelService;
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

                model.CreatedBy = newQuestion.CreatedBy;
                model.CreationTime = DateTime.Now;
                if (String.IsNullOrEmpty(model.Title))
                {
                    GenerateTitleFromText(model);
                }

                await questionRepository.CreateAsync(model);
                return await AddLabelsToNewQuestions(newQuestion, model.CreatedBy);
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

                model.CreatedBy = newQuestion.CreatedBy;
                model.CreationTime = DateTime.Now;

                if (String.IsNullOrEmpty(model.Title))
                {
                    GenerateTitleFromText(model);
                }

                for (int i = 0; i < newQuestion.Methods.Count; i++)
                {
                    var method = newQuestion.Methods[i];
                    if (method.Parameters != null)
                    {
                        object[] parameters = new object[method.Parameters.Length];
                        for (int j = 0; j < parameters.Length; j++)
                        {
                            
                            var obj = JsonObject.Parse(JsonSerializer.Serialize(method.Parameters[j]));

                            try
                            {
                                int number = obj.Deserialize<int>();
                                model.Methods.ToArray()[i].Parameters[j] = Convert.ToInt32(number);
                                continue;
                            }
                            catch (Exception) { }

                            try
                            {
                                double number = obj.Deserialize<double>();
                                model.Methods.ToArray()[i].Parameters[j] = number;
                                continue;
                            }
                            catch (Exception) { }

                            try
                            {
                                bool boolean = obj.Deserialize<bool>();
                                model.Methods.ToArray()[i].Parameters[j] = boolean;
                                continue;
                            }
                            catch (Exception) { }

                            try
                            {
                                char chr = obj.Deserialize<char>();
                                model.Methods.ToArray()[i].Parameters[j] = chr;
                                continue;
                            }
                            catch (Exception) { }

                            try
                            {
                                string str = obj.Deserialize<string>();
                                model.Methods.ToArray()[i].Parameters[j] = str;
                                continue;
                            }
                            catch (Exception) { }
                        }
                    }
                }

                await progQuestionRepository.CreateAsync(model);
                return await AddLabelsToNewQuestions(newQuestion, model.CreatedBy);
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

        public async IAsyncEnumerable<Question> GetQuestionsOfUser(string userID)
        {
            var results = List().Where(x => x.CreatedBy.Id == userID);
            await foreach (var item in results)
            {
                yield return item;
            }
        }

        private async Task<bool> AddLabelsToNewQuestions(QuestionDTO newQuestion, User user)
        {
            var question = await GetQuestionsOfUser(user.Id).OrderByDescending(x => x.CreationTime).FirstOrDefaultAsync();
            if (question is not null && newQuestion.Labels is not null)
            {
                foreach (var label in newQuestion.Labels)
                {
                    label.QuestionID = question.ID;
                    await labelService.Insert(label);
                }
            }
            return question != null;
        }

        private void GenerateTitleFromText(Question model)
        {
            var textBody = model.Text.Split(' ');
            for (int i = 0; i < 3; i++)
            {
                if (textBody.Length > i)
                {
                    model.Title += $"{textBody[i]} ";
                }
            }
            model.Title = model.Title.Trim();
        }
    }
}
