using Backend.Models;

namespace Backend.Controllers
{
    public class UserController
    {
        // TODO: this is only temporary, I hope, that's why repos exist guys...
        private readonly List<User> users;

        public UserController()
        {
            // Initialize with dummy data
            users = new List<User>
            {
                new(){ Username = "user1", Password = "pass1", Email = "user1@example.com" },
                new(){ Username = "user2", Password = "pass2", Email = "user2@example.com" }
            };
        }

        public bool ValidateUser(string username, string password, string email)
        {
            return users.Any(u => u.Username == username && u.Email == email && u.Password == password);
        }
    }
}
