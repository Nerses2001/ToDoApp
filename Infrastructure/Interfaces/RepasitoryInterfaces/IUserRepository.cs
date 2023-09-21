using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.RepasitoryInterfaces
{
    internal interface IUserRepository
    {
        void Create(User user);
    }
}
