using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Models
{
    public class Question
    {
        [Key]
        public string ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }
        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsShared { get; set; }

        public QuestionType QuestionType { get; set; } 

        public string CorrectAnswer { get; set; }

        public double MaxPoints { get; set; }

        [StringLength(100)]
        public string PictureExtensionType { get; set; }

        public byte[] PictureData { get; set; }
    }
}
