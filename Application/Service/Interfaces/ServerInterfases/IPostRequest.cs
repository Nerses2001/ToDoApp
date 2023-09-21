using System.Net;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.ServerInterfases
{
    internal interface IPostRequest
    {
        Task HandlePostRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response);

    }
}
