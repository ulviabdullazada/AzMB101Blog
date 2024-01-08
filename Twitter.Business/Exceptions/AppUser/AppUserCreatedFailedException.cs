using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Exceptions.AppUser
{
    public class AppUserCreatedFailedException : Exception
    {
        public AppUserCreatedFailedException() : base("User cannot be created") { }

        public AppUserCreatedFailedException(string? message) : base(message)
        {
        }
    }
}
