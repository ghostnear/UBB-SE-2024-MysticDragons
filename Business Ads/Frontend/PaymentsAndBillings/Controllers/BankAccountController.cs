using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.PaymentsAndBillings.Models;
using Frontend.PaymentsAndBillings.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Frontend.PaymentsAndBillings.Controllers
{
    public class BankAccountController
    {
        private readonly AccountRepository _accountRepository;

        public BankAccountController()
        {
            _accountRepository = App.ServiceProvider.GetService<AccountRepository>();   
        }

        public void updateBankAccount(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            BankAccount updatedAccount = new BankAccount
            {
                Email = email,
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                County = county,
                City = city,
                Address = address,
                Number = number,
                HolderName = holderName,
                ExpiryDate = expiryDate
            };
            if (!BankAccount.Validate(updatedAccount))
            {
                throw new Exception("Invalid bank account data!");
            }
            else
            {
                _accountRepository.BankAccount = updatedAccount;
            }
        }

        public BankAccount getBankAccount()
        {
            return _accountRepository.BankAccount;
        }
    }
}
