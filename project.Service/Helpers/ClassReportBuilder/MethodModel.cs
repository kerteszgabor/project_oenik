using project.Domain.DTO.ClassReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Service.Helpers.ClassReportBuilder
{
    class MethodModel
    {
        public string MethodName { get; set; }
        public ParamList ExpectedParameters { get; set; }
        public string ExpectedReturnType { get; set; }
        public string ExpectedStringOutput { get; set; }
        public object ExpectedOutput { get; set; }
        public object[] CompilationParameters { get; set; }
        public bool ToBeCompiled { get; set; }

    }
}
