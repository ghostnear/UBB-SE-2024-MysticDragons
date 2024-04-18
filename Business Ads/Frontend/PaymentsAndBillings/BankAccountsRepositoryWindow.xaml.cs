using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Backend.PaymentsAndBillings.Controllers;

namespace Frontend.PaymentsAndBillings
{
    /// <summary>
    /// Interaction logic for BankAccountsRepositoryWindow.xaml
    /// </summary>
    public partial class BankAccountsRepositoryWindow : Window
    {
        public Window mainWindow;
        private readonly BankAccountController _bankAccountController;
        
        public BankAccountsRepositoryWindow(BankAccountController b)
        {
            _bankAccountController = b;
            InitializeComponent();
            UpdateFields();

            Closed += (sender, EventData) =>
            {
                mainWindow.Show();
            };
        }

        private void UpdateFields()
        {
            txtEmail.Text = _bankAccountController.GetBankAccount().Email;
            txtName.Text = _bankAccountController.GetBankAccount().Name;
            txtSurname.Text = _bankAccountController.GetBankAccount().Surname;
            txtPhoneNumber.Text = _bankAccountController.GetBankAccount().PhoneNumber;
            txtCounty.Text = _bankAccountController.GetBankAccount().County;
            txtCity.Text = _bankAccountController.GetBankAccount().City;
            txtAddress.Text = _bankAccountController.GetBankAccount().Address;
            txtNumber.Text = _bankAccountController.GetBankAccount().Number;
            txtHolderName.Text = _bankAccountController.GetBankAccount().HolderName;
            txtExpiryDate.Text = _bankAccountController.GetBankAccount().ExpiryDate;
        }

        private void HomePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _bankAccountController.UpdateBankAccount(txtName.Text, txtSurname.Text, 
                    txtEmail.Text, txtPhoneNumber.Text, txtCounty.Text, txtCity.Text, 
                    txtAddress.Text, txtNumber.Text, txtHolderName.Text, txtExpiryDate.Text);
                MessageBox.Show("Bank account updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateFields();
            }
        }

        private void HomePage_MouseEnter(object sender, MouseEventArgs e)
        {
            homePageBlock.Background = Brushes.LightGray;
        }

        private void HomePage_MouseLeave(object sender, MouseEventArgs e)
        {
            homePageBlock.Background = Brushes.DimGray;
        }

        private void Profile_MouseEnter(object sender, MouseEventArgs e)
        {
            profileBlock.Background = Brushes.LightGray;
        }

        private void Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            profileBlock.Background = Brushes.DimGray;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }
    }
}
