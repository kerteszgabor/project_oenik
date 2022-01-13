using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Domain.Models
{
    public class TestResult
    {
        [Key]
        public string ID { get; set; }
        public Test Test { get; set; }

        public Course Course { get; set; }

        public User User { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public double PointResult { get; set; }

        public List<Answer> Answers { get; set; }

        public bool IsCorrectionFinished { get; set; }
        public bool IsClosed { get; set; }
    }
}
