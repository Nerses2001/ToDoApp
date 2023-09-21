using ToDoAppUsingRepositoryPattern.Infrastructure.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.RepasitoryInterfaces
{
    internal interface IUserRepository
    {
        void CreateUser(User user);
    }
}
