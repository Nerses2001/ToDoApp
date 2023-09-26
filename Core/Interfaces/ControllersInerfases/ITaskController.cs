using System.Net;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.ControllersInerfases
{
    internal interface ITaskController
    {
        Task CreatTask(UserTask userTask, HttpListenerResponse response, string url, string sendUrl);

    }
}
