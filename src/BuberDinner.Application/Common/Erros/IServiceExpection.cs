using System.Net;

namespace BuberDinner.Application.Common.Erros;

public interface IServiceExpection
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
