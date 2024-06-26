using System.Windows;
using Frontend.PaymentsAndBillings;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, eventData) =>
            {
                StatsButton.Click += (sender, eventData) =>
                {
                    StatsWindow statsWindow = new()
                    {
                        mainWindow = this
                    };
                    statsWindow.Show();
                    Hide();
                };
                ExportButton.Click += (sender, eventData) =>
                {
                    ExportWindow exportWindow = new()
                    {
                        mainWindow = this
                    };
                    exportWindow.Show();
                    Hide();
                };
                BillingButton.Click += (sender, eventData) =>
                {
                    PaymentsAndBillingsMain billingWindow = new()
                    {
                        mainWindow = this
                    };
                    billingWindow.Show();
                    Hide();
                };
                faqButton.Click += (sender, eventData) =>
                {
                    FAQWindow faqWindow = new()
                    {
                        mainWindow = this
                    };
                    faqWindow.Show();
                    Hide();
                };

                Closed += (sender, eventData) =>
                {
                    Application.Current.Shutdown();
                };
            };
        }
    }
}
