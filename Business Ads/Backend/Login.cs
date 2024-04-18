using Backend.Controllers;

namespace Backend.Login
{
    public class LoginViewModel
    {
        private readonly UserController userService;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public LoginViewModel()
        {
            userService = new UserController();
        }

        public bool CanLogin()
        {
            return userService.ValidateUser(Username, Password,Email);
        }
    }
}
