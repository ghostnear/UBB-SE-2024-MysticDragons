using System.Windows;
using Backend.PaymentsAndBillings.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Frontend.PaymentsAndBillings
{
    /// <summary>
    /// Interaction logic for PaymentsAndBillingsMain.xaml
    /// </summary>
    public partial class PaymentsAndBillingsMain : Window
    {
        public Window mainWindow;

        public PaymentsAndBillingsMain()
        {
            InitializeComponent();

            Closed += (sender, EventData) =>
            {
                mainWindow.Show();
            };
        }

        private void BankAccountDetails_Click(object sender, RoutedEventArgs e)
        {
            var _bankAccountsRepositoryWindow = new BankAccountsRepositoryWindow(
                App.ServiceProvider.GetService<BankAccountController>()
            );
            _bankAccountsRepositoryWindow.mainWindow = this;
            _bankAccountsRepositoryWindow.Show();
        }

        private void PaymentForm_Click(object sender, RoutedEventArgs e)
        {
            var _paymentForm = new PaymentForm
            {
                mainWindow = this
            };

            _paymentForm.Show();
        }
    }
}
