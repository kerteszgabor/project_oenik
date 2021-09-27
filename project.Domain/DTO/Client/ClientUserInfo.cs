using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.DTO.Client
{
    public class ClientUserInfo
    {
        public string ID { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
