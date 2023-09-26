using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.ServiceInterfaces
{
    internal interface IUserService
    {
        void CreateUser(User user);
        User GetUserByEmail(string email);

    }
}
