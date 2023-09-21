using System.Net;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Core.Models;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{

    internal class RequestProcessor : IRequestProcessor
    {

        private readonly RequestGeneralModel _creatUser;
        private readonly IPostRequest _handlePost;

        public RequestProcessor(IPostRequest postRequest)
        {
            _creatUser = new("/creatuser");
            _handlePost = postRequest;
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
                            await _handlePost.HandlePostRequestAsync<User>(request, response);
                        break;
                    }

            }


        }
    }
}
