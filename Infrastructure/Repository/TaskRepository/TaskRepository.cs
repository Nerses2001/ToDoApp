using Microsoft.EntityFrameworkCore;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Infrastructure.Data.DbContexts;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Repository.TaskRepository
{
    internal class TaskRepository:ITaskRepasitory
    {
        private readonly ToDoAppContext _context;

        public TaskRepository(ToDoAppContext context)
        {
            this._context = context;
        }

        public async Task Create(UserTask userTask)
        {
            _context.UserTasks.Add(userTask);
             await _context.SaveChangesAsync();
        }

        public async Task<List<UserTask>> GetTask(int id)
        {
            var tasks = await _context.UserTasks.Where(task => task.UserId == id).ToListAsync();
            if (tasks != null)
            {
                return tasks;
            }
            throw new Exception("Task not found.");
        }
    }
}
