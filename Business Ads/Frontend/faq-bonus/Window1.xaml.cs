using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Frontend.faq_bonus
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private LoginViewModel loginViewModel;

        public Window1()
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
                MessageBox.Show("Login Successful", "Login Status");
            }
            else
            {
                MessageBox.Show("Invalid username,email or password", "Login Status");
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "Username" || textBox.Text=="Email"))
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Username";
            }
        }
        private void TextBox_LostFocus_Email(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Email";
            }
        }
    }
}
