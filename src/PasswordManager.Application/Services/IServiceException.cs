using System.Net;

namespace PasswordManager.Application.Services;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}