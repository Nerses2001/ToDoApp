//using Newtonsoft.Json;
using System.Text.Json;
using System.Net;
using ToDoAppUsingRepositoryPattern.Core.Models;
using ToDoAppUsingRepositoryPattern.Core.Abstractions.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel.Login;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ControllersInerfases;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{
    internal class HandlePostRequest : BaseResponse, IPostRequest
    {
        private readonly IUserController _userController;
        private readonly ITaskController _taskController;

        public HandlePostRequest(IUserController controller, ITaskController taskController)
        {

            this._userController = controller;
            this._taskController = taskController;

        }
        public async Task HandlePostRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response, string url)
        {
            using StreamReader reader = new(request.InputStream);
            string requestBody = await reader.ReadToEndAsync();
            try
            {
                T model =  JsonSerializer.Deserialize<T>(requestBody)!;
                
                Console.WriteLine(requestBody);
                ResponseModel<int> responseData = new(true, " Data received and processed successfully", 200);

                switch (model)
                {
                    case User user when model is User:
                      //   _userService.CreateUser(user);
                      //   await SendResponse(response, HttpStatusCode.OK, responseData);
                        await _userController.CreatUser(user, response, url, request.Url!.AbsolutePath);
                        break;
                    case UserLogin userLogin:
                        await _userController.LoginUser(userLogin, response, url, request.Url!.AbsolutePath);
                        break;
                    case UserTask userTask:
                        await _taskController.CreatTask(userTask, response, url, request.Url!.AbsolutePath);
                        break;

                }
            }
            catch (Exception ex)
            {
                ResponseModel<string> responseData = new(false, "Bad Request: Invalid request body format", ex.Message);

                await SendResponse(response, HttpStatusCode.BadRequest, responseData);
                await Console.Out.WriteLineAsync(ex.Message);


            }
        }
    }
}
