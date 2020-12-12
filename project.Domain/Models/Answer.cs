using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Domain.Models
{
    public class Answer
    {
        [Key]
        public string ID { get; set; }
        public Question Question { get; set; }
        public string AnswerText { get; set; }
        public bool CorrectManually { get; set; }
    }
}
