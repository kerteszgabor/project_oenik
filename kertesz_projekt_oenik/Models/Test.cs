using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Models
{
    public class Test
    {
        [Key]
        public string ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public DateTime CreationTime { get; set; }

        public User CreatedBy { get; set; }

        public bool IsShared { get; set; }

        public bool IsLateSubmissionAllowed { get; set; }

        public TimeSpan AllowedTakeLength { get; set; }

        public double MaxPoints { get; set; }
    }
}
