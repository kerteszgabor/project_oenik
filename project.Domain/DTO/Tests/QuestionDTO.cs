using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.DTO.Tests
{
    public class QuestionDTO
    {
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }

        [Required]
        public bool IsShared { get; set; }

        [Required]
        public bool CorrectManually { get; set; }

        public string QuestionType { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        [Required]
        public double MaxPoints { get; set; }

        public string PictureExtensionType { get; set; }

        public byte[] PictureData { get; set; }

        public List<LabelDTO> Labels { get; set; }
    }
}
