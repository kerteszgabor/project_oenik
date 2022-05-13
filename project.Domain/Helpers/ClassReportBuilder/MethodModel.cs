using project.Domain.DTO.ClassReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Domain.Helpers.ClassReportBuilder
{
    public class MethodModel
    {
        public string MethodName { get; set; }
        public ParamList ParameterList { get; set; }
        public string ExpectedReturnType { get; set; }
        public string ExpectedStringOutput { get; set; }
        public object ExpectedValue { get; set; }
        public object[] Parameters { get; set; }
        public bool RequireCompilation { get; set; }

    }
}
