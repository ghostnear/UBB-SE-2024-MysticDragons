using System.Windows;
using Backend.PaymentsAndBillings.Models;
using Backend.PaymentsAndBillings.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Frontend.PaymentsAndBillings;
using Backend.PaymentsAndBillings.Repositories;

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

            var bankAccount = new BankAccount
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
            };
            services.AddSingleton(bankAccount);

            var accountRepository = new AccountRepository(bankAccount);
            services.AddSingleton(accountRepository);

            var bankAccountController = new BankAccountController(accountRepository);
            services.AddSingleton(bankAccountController);

            ServiceProvider = services.BuildServiceProvider();

            MainWindow mainWindow = new();
            mainWindow.Show();
        }
    }
}
