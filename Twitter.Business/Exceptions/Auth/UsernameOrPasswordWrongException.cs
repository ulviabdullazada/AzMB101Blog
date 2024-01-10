namespace Twitter.Business.Exceptions.Auth;

public class UsernameOrPasswordWrongException : Exception
{
    public UsernameOrPasswordWrongException() : base("Username or password is wrong")
    {
    }

    public UsernameOrPasswordWrongException(string? message) : base(message)
    {
    }
}
