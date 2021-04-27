using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using project.Domain.DTO.Tests;
using project.Domain.Interfaces;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Services
{
    class TestsService
    {
        private readonly ITestRepository<Test> testRepository;
        public TestsService(ITestRepository<Test> testRepository)
        {
            this.testRepository = testRepository;
        }

        public async Task<bool> Delete(string uid)
        {
            return await testRepository.DeleteAsync(uid);
        }

        public async Task<Test> Get(string uid)
        {
            return await testRepository.GetAsync(uid);
        }

        public async IAsyncEnumerable<Test> List()
        {
            await foreach (var item in testRepository.GetAllAsync())
                yield return item;
        }


        public async Task<bool> Insert(TestDTO newTest)
        {

            if (newTest != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<TestDTO, Test>();
                });
                IMapper iMapper = config.CreateMapper();

                var model = iMapper.Map<TestDTO, Test>(newTest);

                return await testRepository.CreateAsync(model);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(string uid, JsonPatchDocument<Test> patch)
        {
            if (patch != null)
            {
                var test = await testRepository.GetAsync(uid);
                patch.ApplyTo(test);
                var result = await testRepository.UpdateAsync(test);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
