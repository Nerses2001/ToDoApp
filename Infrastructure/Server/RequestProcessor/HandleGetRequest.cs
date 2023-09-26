
using Newtonsoft.Json;
using System.Net;
using ToDoAppUsingRepositoryPattern.Core.Abstractions.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ControllersInerfases;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ServerInterfases;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{
    internal class HandleGetRequest : BaseResponse, IGetRequest
    {
        private readonly ITaskControllerForGet _taskController;
        public HandleGetRequest(ITaskControllerForGet taskController)
        {
            this._taskController = taskController;
        }
        public async Task HandleGetRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response, string url)
        {
            await _taskController.GetUserTask(response, url, request.Url!.AbsolutePath);


        }
    }
}
