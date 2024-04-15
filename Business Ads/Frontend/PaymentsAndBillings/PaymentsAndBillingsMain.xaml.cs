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

namespace Frontend.PaymentsAndBillings
{
    /// <summary>
    /// Interaction logic for PaymentsAndBillingsMain.xaml
    /// </summary>
    public partial class PaymentsAndBillingsMain : Window
    {
        public PaymentsAndBillingsMain()
        {
            InitializeComponent();
        }

        private void BankAccountDetails_Click(object sender, RoutedEventArgs e)
        {
            BankAccountsRepositoryWindow bankAccountsRepositoryWindow = new BankAccountsRepositoryWindow();
            bankAccountsRepositoryWindow.Show();
        }

        private void PaymentForm_Click(object sender, RoutedEventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show();
        }
    }
}
