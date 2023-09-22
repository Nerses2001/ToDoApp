//using Newtonsoft.Json;
using System.Text.Json;
using System.Net;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Core.Models;
using ToDoAppUsingRepositoryPattern.Core.Abstractions.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.UserServiceIntefaces;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Presentation.Interfases;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel.Login;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{
    internal class HandlePostRequest : Response, IPostRequest
    {
        private readonly IUserController _userController;

        public HandlePostRequest(IUserController controller)
        {

            this._userController = controller;
        }
        public async Task HandlePostRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response, string url)
        {
            using StreamReader reader = new(request.InputStream);
            string requestBody = await reader.ReadToEndAsync();
            try
            {
                T model = JsonSerializer.Deserialize<T>(requestBody)!;
                
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
