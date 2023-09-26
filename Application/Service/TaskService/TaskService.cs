using ToDoAppUsingRepositoryPattern.Core.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.TaskServiceInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Application.Service.TaskService
{
    internal class TaskService : ITaskService
    {
        private readonly ITaskRepasitory _taskRepasitory;

        public TaskService(ITaskRepasitory taskRepasitory)
        {
            this._taskRepasitory = taskRepasitory;   
           
        }

        public async Task CreateTask(UserTask userTask)
        {
            await _taskRepasitory.Create(userTask);
        }

        public async Task<List<UserTask>> GetUserTask(int userId)
        {
            return await _taskRepasitory.GetTask(userId);
        }
    }
}
