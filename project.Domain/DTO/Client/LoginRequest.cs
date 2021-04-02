using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.DTO.Client
{
    public class LoginRequest
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string userName { get; set; }

        [StringLength(50)]
        [Required]
        public string Password { get; set; }
    }
}
