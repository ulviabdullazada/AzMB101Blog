using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Exceptions.AppUser
{
    public class AppUserCreatedFailedException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;
        public string ErrorMessage { get; set; } 
        public AppUserCreatedFailedException() 
        {
            ErrorMessage = "User cannot be created";
        }

        public AppUserCreatedFailedException(string? message)
        {
            ErrorMessage = message;
        }

    }
}
