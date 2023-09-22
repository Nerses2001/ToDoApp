

using System.Net;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel.Login;

namespace ToDoAppUsingRepositoryPattern.Presentation.Interfases
{
    internal interface IUserController
    {
        Task CreatUser(User user, HttpListenerResponse response, string url, string sendUrl);
        Task LoginUser(UserLogin user, HttpListenerResponse response, string url, string sendUrl);

    }
}
