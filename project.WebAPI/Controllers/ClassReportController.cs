using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using project.Domain.DTO.ClassReport;
using project.Service.Helpers.ClassReportBuilder;
using project.Service.Interfaces;

namespace project.WebAPI.Controllers
{
    [EnableCors("cors")]
    [Route("classreport")]
    [ApiController]
    public class ClassReportController : ControllerBase
    {
        private readonly IClassReportBuilder builder;

        public ClassReportController(IClassReportBuilder builder)
        {
            this.builder = builder;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddClass([FromBody] ClassRequestBody classData)
        {
            var buildObject = builder.GetReportOf(classData.Code);
            foreach (var method in classData.Methods)
            {
                ICanRequireCompilation methodObject = null;
                if (method.ParameterList != null && method.ExpectedReturnType != null)
                {
                    methodObject = buildObject.WithMethod(method.MethodName, method.ParameterList, method.ExpectedReturnType);
                }
                else if (method.ParameterList != null)
                {
                    methodObject = buildObject.WithMethod(method.MethodName, method.ParameterList);
                }
                else if (method.ExpectedReturnType != null)
                {
                    methodObject = buildObject.WithMethod(method.MethodName, method.ExpectedReturnType);
                }
                else
                {
                    methodObject = buildObject.WithMethod(method.MethodName);
                }
                if (method.RequireCompilation)
                {
                    ICanCompile compileObject = methodObject.AlsoCompile();
                    if (method.Parameters != null)
                    {
                        object[] parameters = new object[method.Parameters.Length];
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            var node = (JsonElement)method.Parameters[i];
                            if (node.ValueKind == JsonValueKind.Number)
                            {
                                parameters[i] = JsonConvert.DeserializeObject(method.Parameters[i].ToString());
                            }
                            else
                            {
                                parameters[i] = node.GetString();
                            }
                           
                        }
                        compileObject.WithParameters(parameters);
                    }
                    if (method.ExpectedStringOutput != null)
                    {
                        compileObject = compileObject.SetExpectedStringOutput(method.ExpectedStringOutput);
                    }
                    if (method.ExpectedValue != null)
                    {
                        compileObject = compileObject.SetExpectedValue(method.ExpectedValue);
                    }
                }
            }
            var report = buildObject.Build();
            return Ok(report);
        }
    }
}