using Microsoft.AspNetCore.Http;
using Twitter.Core.Entities.Common;

namespace Twitter.Business.Exceptions.Common
{
    public class NotFoundException<T> : Exception, IBaseException where T : BaseEntity
    {
        public NotFoundException()
        {
            ErrorMessage = typeof(T).Name + " not found";
        }

        public NotFoundException(string? message)
        {
            ErrorMessage = message;
        }

        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; set; }
    }
}
