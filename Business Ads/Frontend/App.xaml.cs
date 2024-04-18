using Frontend.PaymentsAndBillings.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Frontend.PaymentsAndBillings;
using Frontend.PaymentsAndBillings.Models;
using Frontend.PaymentsAndBillings.Repositories;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddSingleton<BankAccount>(new BankAccount
            {
                Email = "osvathrobert03@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23"
            });
            services.AddSingleton<AccountRepository>();
            services.AddSingleton<BankAccountController>();
            services.AddSingleton<BankAccountsRepositoryWindow>();
            services.AddSingleton<PaymentForm>();
            ServiceProvider = services.BuildServiceProvider();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
