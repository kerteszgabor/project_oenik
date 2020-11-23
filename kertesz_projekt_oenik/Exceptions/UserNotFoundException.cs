using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Exceptions
{
    public class UserNotFoundException : Exception
    {
    }

    public class CannotAddUserException : Exception
    {
        public List<IdentityError> IdentityErrors { get; set; }
        public CannotAddUserException(IEnumerable<IdentityError> errorsOccured)
        {
            this.IdentityErrors = errorsOccured.ToList();
        }
    }
}
