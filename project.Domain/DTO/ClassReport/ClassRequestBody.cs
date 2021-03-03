using System;
using System.Collections.Generic;
using System.Text;

namespace project.Domain.DTO.ClassReport
{
    public class ClassRequestBody
    {
        public string Code { get; set; }
        public List<MethodInfoData> Methods { get; set; }
    }
}
