using project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.DTO.Tests
{
    public class TestDTO
    {
        public string Title { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatedBy { get; set; }

        public bool IsShared { get; set; }

        public bool IsLateSubmissionAllowed { get; set; }

        public TimeSpan AllowedTakeLength { get; set; }

        public double MaxPoints { get; set; }
    }
}
