using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Backend.Controllers;

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
            var _paymentForm = new PaymentForm(
                App.ServiceProvider.GetService<PaymentFormController>()
            );
            _paymentForm.mainWindow = this;
            _paymentForm.Show();
        }
    }
}
