using Backend.PaymentsAndBillings.Models;
using Backend.PaymentsAndBillings.Repositories;

namespace Backend.PaymentsAndBillings.Controllers
{
    public class BankAccountController(AccountRepository repository)
    {
        private readonly AccountRepository _accountRepository = repository;

        public void UpdateBankAccount(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            BankAccount updatedAccount = new()
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

        public BankAccount GetBankAccount()
        {
            return _accountRepository.BankAccount;
        }
    }
}
