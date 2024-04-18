using Backend.Login;
using System.Windows;
using System.Windows.Controls;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel loginViewModel;

        public LoginWindow()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();  // Initialize the ViewModel
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            loginViewModel.Username = UsernameTextBox.Text;
            loginViewModel.Password = PasswordTextBox.Password;
            loginViewModel.Email = EmailTextBox.Text;

            if (loginViewModel.CanLogin())
            {
                MessageBox.Show("You have been logged in successfully.", "Login success!");
                MainWindow window = new();
                window.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid account credentials.", "Login failed!");
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "";
            }
        }
        private void TextBox_LostFocus_Email(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "";
            }
        }
    }
}
