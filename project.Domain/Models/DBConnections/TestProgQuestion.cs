using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace project.Domain.Models.DBConnections
{
    public class TestProgQuestion
    {
        [Key]
        public string ID { get; set; }
        public string TestID { get; set; }
        [JsonIgnore]
        public Test Test { get; set; }
        public string ProgrammingQuestionID { get; set; }
        [JsonIgnore]
        public ProgrammingQuestion ProgrammingQuestion { get; set; }
    }
}
