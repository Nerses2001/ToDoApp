

using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.UserServiceIntefaces;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.RepasitoryInterfaces;

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
    }
}
