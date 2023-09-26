

using System.Net;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.ServerInterfases
{
    internal interface IRequestProcessor
    {
        Task HandleRequestAsync(HttpListenerContext context);
    }
}
