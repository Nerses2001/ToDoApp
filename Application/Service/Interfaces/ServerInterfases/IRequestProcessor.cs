

using System.Net;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.ServerInterfases
{
    internal interface IRequestProcessor
    {
        Task HandlePostRequestAsync(HttpListenerContext context);
    }
}
