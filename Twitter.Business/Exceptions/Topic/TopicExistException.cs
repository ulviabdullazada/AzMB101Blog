namespace Twitter.Business.Exceptions.Topic
{
    public class TopicExistException : Exception
    {
        public TopicExistException() : base("Topic already added")
        {
        }

        public TopicExistException(string? message) : base(message)
        {
        }
    }
}
