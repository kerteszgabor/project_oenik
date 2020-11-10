using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Models
{
    public class Course
    {
        [Key]
        public string ID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        List<User> Teachers { get; set; }

        List<User> Students { get; set; }
    }
}
