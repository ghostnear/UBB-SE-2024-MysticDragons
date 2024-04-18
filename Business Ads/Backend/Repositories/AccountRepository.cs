using Backend.Models;
using Backend.Services;

namespace Backend.Repositories
{
    public class AccountRepository
    {
        private BankAccount _bankAccount;
        private string _emailKey;
        private string _nameKey;
        private string _surnameKey;
        private string _phoneNumberKey;
        private string _countyKey;
        private string _cityKey;
        private string _addressKey;
        private string _numberKey;
        private string _holderNameKey;
        private string _expiryDateKey;
        
        public BankAccount BankAccount
        {
            get
            {
                string decryptedEmail = DataEncryptionService.Decrypt(_bankAccount.Email, _emailKey);
                string decryptedName = DataEncryptionService.Decrypt(_bankAccount.Name, _nameKey);
                string decryptedSurname = DataEncryptionService.Decrypt(_bankAccount.Surname, _surnameKey);
                string decryptedPhoneNumber = DataEncryptionService.Decrypt(_bankAccount.PhoneNumber, _phoneNumberKey);
                string decryptedCounty = DataEncryptionService.Decrypt(_bankAccount.County, _countyKey);
                string decryptedCity = DataEncryptionService.Decrypt(_bankAccount.City, _cityKey);
                string decryptedAddress = DataEncryptionService.Decrypt(_bankAccount.Address, _addressKey);
                string decryptedNumber = DataEncryptionService.Decrypt(_bankAccount.Number, _numberKey);
                string decryptedHolderName = DataEncryptionService.Decrypt(_bankAccount.HolderName, _holderNameKey);
                string decryptedExpiryDate = DataEncryptionService.Decrypt(_bankAccount.ExpiryDate, _expiryDateKey);
                return new BankAccount
                {
                    Email = decryptedEmail,
                    Name = decryptedName,
                    Surname = decryptedSurname,
                    PhoneNumber = decryptedPhoneNumber,
                    County = decryptedCounty,
                    City = decryptedCity,
                    Address = decryptedAddress,
                    Number = decryptedNumber,
                    HolderName = decryptedHolderName,
                    ExpiryDate = decryptedExpiryDate
                };
            }
            set
            {
                Dictionary<string, string> encryptedEmailKVPair = DataEncryptionService.Encrypt(value.Email);
                string encryptedEmail = encryptedEmailKVPair["data"];
                _emailKey = encryptedEmailKVPair["key"];
                Dictionary<string, string> encryptedNameKVPair = DataEncryptionService.Encrypt(value.Name);
                string encryptedName = encryptedNameKVPair["data"];
                _nameKey = encryptedNameKVPair["key"];
                Dictionary<string, string> encryptedSurnameKVPair = DataEncryptionService.Encrypt(value.Surname);
                string encryptedSurname = encryptedSurnameKVPair["data"];
                _surnameKey = encryptedSurnameKVPair["key"];
                Dictionary<string, string> encryptedPhoneNumberKVPair = DataEncryptionService.Encrypt(value.PhoneNumber);
                string encryptedPhoneNumber = encryptedPhoneNumberKVPair["data"];
                _phoneNumberKey = encryptedPhoneNumberKVPair["key"];
                Dictionary<string, string> encryptedCountyKVPair = DataEncryptionService.Encrypt(value.County);
                string encryptedCounty = encryptedCountyKVPair["data"];
                _countyKey = encryptedCountyKVPair["key"];
                Dictionary<string, string> encryptedCityKVPair = DataEncryptionService.Encrypt(value.City);
                string encryptedCity = encryptedCityKVPair["data"];
                _cityKey = encryptedCityKVPair["key"];
                Dictionary<string, string> encryptedAddressKVPair = DataEncryptionService.Encrypt(value.Address);
                string encryptedAddress = encryptedAddressKVPair["data"];
                _addressKey = encryptedAddressKVPair["key"];
                Dictionary<string, string> encryptedNumberKVPair = DataEncryptionService.Encrypt(value.Number);
                string encryptedNumber = encryptedNumberKVPair["data"];
                _numberKey = encryptedNumberKVPair["key"];
                Dictionary<string, string> encryptedHolderNameKVPair = DataEncryptionService.Encrypt(value.HolderName);
                string encryptedHolderName = encryptedHolderNameKVPair["data"];
                _holderNameKey = encryptedHolderNameKVPair["key"];
                Dictionary<string, string> encryptedExpiryDateKVPair = DataEncryptionService.Encrypt(value.ExpiryDate);
                string encryptedExpiryDate = encryptedExpiryDateKVPair["data"];
                _expiryDateKey = encryptedExpiryDateKVPair["key"];
                _bankAccount =  new BankAccount
                {
                    Email = encryptedEmail,
                    Name = encryptedName,
                    Surname = encryptedSurname,
                    PhoneNumber = encryptedPhoneNumber,
                    County = encryptedCounty,
                    City = encryptedCity,
                    Address = encryptedAddress,
                    Number = encryptedNumber,
                    HolderName = encryptedHolderName,
                    ExpiryDate = encryptedExpiryDate
                };
            }
        }

        public AccountRepository(BankAccount account)
        {
            BankAccount = account;
        }
    }
}
