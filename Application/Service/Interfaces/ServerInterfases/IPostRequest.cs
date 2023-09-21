using System.Net;

namespace ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases
{
    internal interface IPostRequest
    {
        Task HandlePostRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response);

    }
}
