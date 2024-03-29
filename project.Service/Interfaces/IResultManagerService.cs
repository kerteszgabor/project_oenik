﻿using Microsoft.AspNetCore.JsonPatch;
using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Service.Interfaces
{
    public interface IResultManagerService
    {
        Task<TestResult> Get(string uid);
        Task<bool> Delete(string uid);
        Task<bool> Update(string uid, JsonPatchDocument<TestResult> patch);
        IAsyncEnumerable<TestResult> GetAllResults();
        IAsyncEnumerable<TestResult> GetTestResultsOfUser(string userID);
        IAsyncEnumerable<TestResult> GetTestResultsOfTestOfCourse(string courseID, string testID);
        IAsyncEnumerable<TestResult> GetTestResultOfUserOfTest(string userID, string testID);
    }
}
