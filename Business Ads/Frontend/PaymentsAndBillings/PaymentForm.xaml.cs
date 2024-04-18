using Backend.PaymentsAndBillings.Controllers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Frontend.PaymentsAndBillings
{
    /// <summary>
    /// Interaction logic for PaymentForm.xaml
    /// </summary>
    public partial class PaymentForm : Window
    {
        public Window mainWindow;
        private readonly PaymentFormController _paymentController;

        public PaymentForm(PaymentFormController c)
        {
            _paymentController = c;
            InitializeComponent();
            UpdateFields();

            Closed += (sender, EventData) =>
            {
                mainWindow.Show();
            };
        }

        private void UpdateFields()
        {
            itemName.Text = _paymentController.getProduct().Name;
            itemDescription.Text = _paymentController.getProduct().Description;
            itemPrice.Text = _paymentController.getProduct().Price;
            var itemImageSource = _paymentController.getProduct().Image;
            itemImage.Source = new BitmapImage(new Uri(itemImageSource, UriKind.Relative));
        }

        private async void PayButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _paymentController.SendPaymentConfirmationMailAsync();
                MessageBox.Show("Payment sent successfully!");
            }
            catch
            {
                MessageBox.Show("Payment failed!");
            }
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
            MessageBox.Show("Changes saved successfully!");
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
