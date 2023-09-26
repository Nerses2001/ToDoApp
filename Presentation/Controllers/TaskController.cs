using System.Net;
using ToDoAppUsingRepositoryPattern.Core.Abstractions.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ControllersInerfases;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.TaskServiceInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Models;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Presentation.Controllers
{
    internal class TaskController: BaseResponse, ITaskController, ITaskControllerForGet
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            this._taskService = taskService;
        }

        public async Task CreatTask(UserTask userTask, HttpListenerResponse response, string url, string sendUrl)
        {
            if (sendUrl.StartsWith(url))
            {
                ResponseModel<int> responseData = new(true, " Data received and processed successfully", 200);
                await _taskService.CreateTask(userTask);
                await SendResponse<ResponseModel<int>>(response, HttpStatusCode.OK, responseData);
            }
        }

        public async Task GetUserTask(HttpListenerResponse response, string url, string sendUrl)
        {
            Console.WriteLine(url);
            Console.WriteLine(sendUrl);
            Console.WriteLine(sendUrl.StartsWith(url));
            if (sendUrl.StartsWith(url) && int.TryParse(sendUrl.AsSpan(url.Length), out int userId))
            {

                var taskes = await _taskService.GetUserTask(userId);
                await SendResponse<List<UserTask>>(response, HttpStatusCode.OK, taskes);

            }
        }
    }
}
