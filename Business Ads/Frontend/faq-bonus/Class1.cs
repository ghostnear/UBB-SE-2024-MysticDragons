using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Frontend.faq_bonus
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class UserService
    {
        private List<User> users;

        public UserService()
        {
            // Initialize with dummy data
            users = new List<User>
        {
            new User { Username = "user1", Password = "pass1", Email = "user1@example.com" },
            new User { Username = "user2", Password = "pass2", Email = "user2@example.com" }
        };
        }

        public bool ValidateUser(string username, string password)
        {
            return users.Any(u => u.Username == username && u.Password == password);
        }
    }
    public class LoginViewModel
    {
        private UserService userService;

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            userService = new UserService();
        }

        public bool CanLogin()
        {
            return userService.ValidateUser(Username, Password);
        }
    }


}
