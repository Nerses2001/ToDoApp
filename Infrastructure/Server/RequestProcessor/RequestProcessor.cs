using System.Net;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Core.Models;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel.Login;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{

    internal class RequestProcessor : IRequestProcessor
    {

        private readonly RequestGeneralModel _creatUser;
        private readonly RequestGeneralModel _loginUser;
        private readonly RequestGeneralModel _createTask;
        private readonly RequestGeneralModel _getTasks;

        private readonly IPostRequest _handlePost;
        private readonly IGetRequest _handleGet;
        

        public RequestProcessor(IPostRequest postRequest, IGetRequest getRequest)
        {
            this._creatUser = new("/creatuser");
            this._loginUser = new("/login");
            this._createTask = new("/creattask");
            this._getTasks = new("/gettasks", "GET");
            this._handlePost = postRequest;
            this._handleGet = getRequest;
        }

        public async Task HandleRequestAsync(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            switch (request.HttpMethod)
            {
                case "POST":
                    {
                        if (_creatUser.EndUrl == request.Url!.AbsolutePath && _creatUser.CType == request.ContentType)
                            await _handlePost.HandlePostRequestAsync<User>(request, response, _creatUser.EndUrl);
                        else if (request.Url!.AbsolutePath.StartsWith(_loginUser.EndUrl) && _creatUser.CType == request.ContentType)
                            await _handlePost.HandlePostRequestAsync<UserLogin>(request, response, _loginUser.EndUrl) ;
                        else if (request.Url!.AbsolutePath.StartsWith(_createTask.EndUrl) && _creatUser.CType == request.ContentType)
                            await _handlePost.HandlePostRequestAsync<UserTask>(request, response, _loginUser.EndUrl);
                        break;
                    }
                case "GET":
                    {
                        Console.WriteLine(request.Url!.AbsolutePath);
                        Console.WriteLine(_getTasks.EndUrl);
                        Console.WriteLine(request.Url!.AbsolutePath.StartsWith(_getTasks.EndUrl));
                        if (request.Url!.AbsolutePath.StartsWith(_getTasks.EndUrl) /*&& _getTasks.CType == request.ContentType*/)
                             await _handleGet.HandleGetRequestAsync<List<UserTask>>(request, response, _getTasks.EndUrl);

                        break;
                    }

            }


        }
    }
}
