using System.Net;
using ToDoAppUsingRepositoryPattern.Core.Abstractions.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ControllersInerfases;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ServiceInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Models;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel.Login;

namespace ToDoAppUsingRepositoryPattern.Presentation.Controllers
{
    internal class UserController: BaseResponse,IUserController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        public async Task CreatUser(User user, HttpListenerResponse response, string url, string sendUrl)
        {
            if (url == sendUrl)
            {
                ResponseModel<int> responseData = new(true, " Data received and processed successfully", 200);
                _userService.CreateUser(user);
                await SendResponse<ResponseModel<int>>(response, HttpStatusCode.OK, responseData);
            }
        }

        public async Task LoginUser(UserLogin user, HttpListenerResponse response, string url, string sendUrl)
        {

            if (sendUrl?.StartsWith(url) ?? false)
            {
                string userEmail = sendUrl[url.Length..];

                if (!IsValidEmail(userEmail))
                {
                    throw new Exception("Invalid email format");
                }

                User getUser = _userService.GetUserByEmail(userEmail);
                if (getUser != null && !string.IsNullOrEmpty(user.PasswordHash) && user.PasswordHash == getUser.PasswordHash)
                {
                    ResponseModel<User> responseData = new(true, "Data received and processed successfully", getUser);
                    await SendResponse(response, HttpStatusCode.OK, responseData);
                }
                else
                {
                    throw new Exception("Invalid user credentials");
                }
            }
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }




    }
}
