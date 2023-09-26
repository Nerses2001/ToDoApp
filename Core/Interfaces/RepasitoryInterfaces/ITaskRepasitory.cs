using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.RepasitoryInterfaces
{
    internal interface ITaskRepasitory
    {
        Task Create(UserTask userTask);
        Task<List<UserTask>> GetTask(int id);

    }
}
