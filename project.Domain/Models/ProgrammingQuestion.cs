using project.Domain.DTO.ClassReport;
using project.Domain.Models.DBConnections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Domain.Models
{
    public class ProgrammingQuestion : Question
    {
        public int OptimalNumberOfLines { get; set; }

        public int ReferenceComplexityLevel { get; set; }

        public TimeSpan ReferenceRuntime { get; set; }

        public string ExpectedOutput { get; set; }

        public ICollection<TestProgQuestion> TestProgQuestions { get; set; }

        public ICollection<MethodInfoData> Methods { get; set; }
    }
}
