namespace ToDoAppUsingRepositoryPattern.Core.Models.UserModel.Login
{
    internal class UserLogin
    {
        public string PasswordHash { get; private set; }

        public UserLogin(string passwordHash)
        {
            this.PasswordHash = passwordHash;
        }
    }
}
