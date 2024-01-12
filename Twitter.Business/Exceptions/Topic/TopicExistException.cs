using Microsoft.AspNetCore.Http;

namespace Twitter.Business.Exceptions.Topic
{
    public class TopicExistException : Exception, IBaseException
    {
        public TopicExistException()
        {
            ErrorMessage = "Topic already added";
        }

        public TopicExistException(string? message)
        {
            ErrorMessage = message;
        }

        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; set; }
    }
}
