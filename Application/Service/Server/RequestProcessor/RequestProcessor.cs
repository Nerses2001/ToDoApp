using System.Net;
using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Infrastructure.Models;
using ToDoAppUsingRepositoryPattern.Infrastructure.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{

    internal class RequestProcessor: IRequestProcessor
    {

        private readonly RequestGeneralModel _creatUser;
        private readonly HandlePostRequest _handlePost;

        public RequestProcessor()
        {
            this._creatUser = new("/creatuser");
            this._handlePost = new();
        }

        public async Task  HandlePostRequestAsync(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            switch (request.HttpMethod)
            {
                case "POST":
                    {
                        if(_creatUser.EndUrl == request.Url!.AbsolutePath && _creatUser.CType == request.ContentType)
                            await _handlePost.HandlePostRequestAsync<User>(request, response);
                        break;
                    }
                    
            }


        }
    }
}
