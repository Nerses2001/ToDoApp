using System.Net;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.ServerInterfases
{
    internal interface IPostRequest
    {
        Task HandlePostRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response, string url);

    }
}
