using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Models
{
    public class QuestionLabel
    {
        [Key]
        public string ID { get; set; }

        public Question Question { get; set; }
        public string LabelText { get; set; }
    }
}
