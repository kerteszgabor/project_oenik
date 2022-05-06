using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace project.Domain.DTO.ClassReport
{
    public class MethodInfoData
    {
        public string MethodName { get; set; }
        public ParamList ParameterList { get; set; }
        public object[] Parameters { get; set; }
        public string ExpectedReturnType { get; set; }
        public string ExpectedStringOutput { get; set; }
        public string ExpectedValue { get; set; }
        [Required]
        public bool RequireCompilation { get; set; }
    }
}
