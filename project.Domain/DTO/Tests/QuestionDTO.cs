using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.DTO.Tests
{
    public class QuestionDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }

        public bool IsShared { get; set; }
        public bool CorrectManually { get; set; }

        public string QuestionType { get; set; }

        public string CorrectAnswer { get; set; }

        public double MaxPoints { get; set; }

        public string PictureExtensionType { get; set; }

        public byte[] PictureData { get; set; }
    }
}
