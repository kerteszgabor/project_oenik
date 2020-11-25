using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Domain.Models
{
    public class QuestionLabel : BaseEntity
    {
        public Question Question { get; set; }
        public string LabelText { get; set; }
    }
}
