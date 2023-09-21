using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.UserServiceIntefaces
{
    internal interface IUSerService
    {
        Task CreateUserAsync(User user);
    }
}
