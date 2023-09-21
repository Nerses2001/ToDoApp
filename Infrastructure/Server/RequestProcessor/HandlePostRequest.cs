//using Newtonsoft.Json;
using System.Text.Json;
using System.Net;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Core.Models;
using ToDoAppUsingRepositoryPattern.Core.Abstractions.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.UserServiceIntefaces;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{
    internal class HandlePostRequest : Response, IPostRequest
    {
        private readonly IUserService _userService;

        public HandlePostRequest(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandlePostRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response)
        {
            using StreamReader reader = new(request.InputStream);
            string requestBody = await reader.ReadToEndAsync();
            try
            {
                T model = JsonSerializer.Deserialize<T>(requestBody)!;
                
                Console.WriteLine(requestBody);
                switch (model)
                {
                    case User user:
                        ResponseModel<int> responseData = new(true, " Data received and processed successfully", 200);
                        _userService.CreateUser(user);
                        await SendResponse(response, HttpStatusCode.OK, responseData);
                        
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
