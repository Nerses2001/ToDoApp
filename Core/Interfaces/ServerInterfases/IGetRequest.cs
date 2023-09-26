using System.Net;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.ServerInterfases
{
    internal interface IGetRequest
    {
        Task HandleGetRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response, string url);
    }
}
