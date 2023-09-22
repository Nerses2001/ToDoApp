using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.UserServiceIntefaces
{
    internal interface IUserService
    {
        void CreateUser(User user);
        User GetUserByEmail(string email);

    }
}
