using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Models.DBConnections
{
    public class UserCourse
    {
        [Key]
        public string ID { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }

        public string CourseID { get; set; }
        public Course Course { get; set; }
    }
}
