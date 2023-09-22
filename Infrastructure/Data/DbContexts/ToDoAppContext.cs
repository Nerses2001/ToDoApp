using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Data.DbContexts
{
    internal class ToDoAppContext: DbContext
    {

        public DbSet<User> Users { get; private set; }
       public DbSet<UserTask> UserTasks { get; private set; }


        public ToDoAppContext() : base(GetDbContextOptions())
        {
            Database.EnsureCreated();
        }

        private static DbContextOptions<ToDoAppContext> GetDbContextOptions()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-CL9R2P4",
                InitialCatalog = "to_do_app",
                IntegratedSecurity = true,
                TrustServerCertificate = true,

            };

            var optionsBuilder = new DbContextOptionsBuilder<ToDoAppContext>();
            optionsBuilder.UseSqlServer(builder.ConnectionString);

            return optionsBuilder.Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasAlternateKey(e => e.PhoneNumber);
            modelBuilder.Entity<UserTask>()
                  .HasOne<User>(ut => ut.User)
                  .WithMany(u => u.UserTasks)
                  .HasForeignKey(ut => ut.UserId);
        }
    }
}
