using Microsoft.AspNetCore.Http;

namespace Twitter.Business.Exceptions.Auth;

public class UsernameOrPasswordWrongException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status400BadRequest;
    public string ErrorMessage { get; set; }

    public UsernameOrPasswordWrongException()
    {
        ErrorMessage = "Username or password is wrong";
    }

    public UsernameOrPasswordWrongException(string? message)
    {
        ErrorMessage = message;
    }

}
