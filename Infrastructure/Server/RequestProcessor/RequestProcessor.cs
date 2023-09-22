using System.Net;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Core.Models;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel.Login;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{

    internal class RequestProcessor : IRequestProcessor
    {

        private readonly RequestGeneralModel _creatUser;
        private readonly RequestGeneralModel _loginUser;

        private readonly IPostRequest _handlePost;


        public RequestProcessor(IPostRequest postRequest)
        {
            this._creatUser = new("/creatuser");
            this._loginUser = new($"/login");
            this._handlePost = postRequest;
        }

        public async Task HandlePostRequestAsync(HttpListenerContext context)
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
                        
                        
                        break;
                    }

            }


        }
    }
}
