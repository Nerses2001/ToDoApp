using ToDoAppUsingRepositoryPattern.Core.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Infrastructure.Data.DbContexts;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Repository.UserRepository
{
    internal class UserRepository:IUserRepository
    {
        private readonly ToDoAppContext _context;
        public UserRepository(ToDoAppContext context)
        {
            this._context = context;    
        }

        public  void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email)!;
        }
    }
}
