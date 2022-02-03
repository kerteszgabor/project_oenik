using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.DTO.TestResults
{
    public class TestStartDTO
    {
        public string QuestionID { get; set; }
        public string TestID { get; set; }
        public string CourseID { get; set; }
        public User User { get; set; }
    }
}
