using ToDoAppUsingRepositoryPattern.Core.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ServiceInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Application.Service.UserService
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public void CreateUser(User user)
        {
            _userRepository.Create(user);
        }

        public User GetUserByEmail(string email)
        {
           return _userRepository.GetByEmail(email);
        }
    }
}
