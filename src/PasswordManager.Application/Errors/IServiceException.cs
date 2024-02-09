using System.Net;

namespace PasswordManager.Application.Errors;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}