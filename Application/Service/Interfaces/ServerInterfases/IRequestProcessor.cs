

using System.Net;

namespace ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases
{
    internal interface IRequestProcessor
    {
        Task HandlePostRequestAsync(HttpListenerContext context);
    }
}
