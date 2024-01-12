namespace Twitter.Business.Exceptions
{
    public interface IBaseException
    {
        public int StatusCode { get; }
        public string ErrorMessage { get; set; }
    }
}
