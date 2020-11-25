using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Domain.Models.DBConnections
{
    public class TestQuestion
    {
        [Key]
        public string ID { get; set; }
        public string TestID { get; set; }
        public Test Test { get; set; }

        public string QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
