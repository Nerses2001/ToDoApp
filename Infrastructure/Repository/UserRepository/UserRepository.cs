﻿using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;
using ToDoAppUsingRepositoryPattern.Infrastructure.Data.DbContexts;
using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.RepasitoryInterfaces;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Repository.UserRepository
{
    internal class UserRepository:IUserRepository
    {
        private readonly ToDoAppContext _context;
        public UserRepository(ToDoAppContext _context)
        {
            this._context = _context;    
        }

        public  void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
