using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.TaskServiceInterfaces
{
    internal interface ITaskService
    {
        Task CreateTask(UserTask userTask);
        Task<List<UserTask>> GetUserTask(int userId);


    }
}
