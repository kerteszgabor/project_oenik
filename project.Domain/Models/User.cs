﻿using Microsoft.AspNetCore.Identity;
using project.Domain.Models.DBConnections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace project.Domain.Models
{
    public class User : IdentityUser
    {
        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        public DateTime LastLogin { get; set; } 

        [StringLength(15)]
        public string LastIP { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
        
        public User CreatedBy { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }
    }
}
