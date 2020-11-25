using project.Domain.Models.DBConnections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Domain.Models
{
    public class Course : BaseEntity
    {
        [StringLength(150)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }

        public ICollection<CourseTest> CourseTests { get; set; }

    }
}
