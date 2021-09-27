using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Domain.DTO.Auth
{
    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IPAddress { get; set; }
    }
}
