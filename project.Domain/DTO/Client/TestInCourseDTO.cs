using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.DTO.Client
{
    public class TestInCourseDTO
    {
        public string TestID { get; set; }
        public string CourseID { get; set; }
        public string AllowedIPSubnet { get; set; }
        public bool IsOpen { get; set; }
    }
}
