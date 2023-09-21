using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Infrastructure.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Repository.UserRepository
{
    internal class UserRepository:IUserRepository
    {
        private readonly List<User> _users = new();

        public  void CreateUser(User user)
        {
            _users.Add(user);
        }
    }
}
