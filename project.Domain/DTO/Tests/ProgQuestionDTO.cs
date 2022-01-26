using project.Domain.DTO.ClassReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.DTO.Tests
{
    public class ProgQuestionDTO : QuestionDTO
    {
        public int OptimalNumberOfLines { get; set; }

        public int ReferenceComplexityLevel { get; set; }

        public string ReferenceRuntime { get; set; }

        public List<MethodInfoData> Methods { get; set; }
    }
}
