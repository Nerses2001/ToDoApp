using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.RepasitoryInterfaces
{
    internal interface IUserRepository
    {
        void Create(User user);
        User GetByEmail(string email);
    }
}
