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
using Frontend.PaymentsAndBillings.Controllers;

namespace Frontend.PaymentsAndBillings
{
    /// <summary>
    /// Interaction logic for BankAccountsRepositoryWindow.xaml
    /// </summary>
    public partial class BankAccountsRepositoryWindow : Window
    {
        private readonly BankAccountController _bankAccountController;
        
        public BankAccountsRepositoryWindow(BankAccountController b)
        {
            _bankAccountController = b;
            InitializeComponent();
            updateFields();
        }

        private void updateFields()
        {
            txtEmail.Text = _bankAccountController.getBankAccount().Email;
            txtName.Text = _bankAccountController.getBankAccount().Name;
            txtSurname.Text = _bankAccountController.getBankAccount().Surname;
            txtPhoneNumber.Text = _bankAccountController.getBankAccount().PhoneNumber;
            txtCounty.Text = _bankAccountController.getBankAccount().County;
            txtCity.Text = _bankAccountController.getBankAccount().City;
            txtAddress.Text = _bankAccountController.getBankAccount().Address;
            txtNumber.Text = _bankAccountController.getBankAccount().Number;
            txtHolderName.Text = _bankAccountController.getBankAccount().HolderName;
            txtExpiryDate.Text = _bankAccountController.getBankAccount().ExpiryDate;
        }

        private void HomePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _bankAccountController.updateBankAccount(txtName.Text, txtSurname.Text, 
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
                updateFields();
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
