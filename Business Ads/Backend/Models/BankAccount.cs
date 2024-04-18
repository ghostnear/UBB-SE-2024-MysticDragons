using System.ComponentModel.DataAnnotations;

namespace Backend.PaymentsAndBillings.Models
{
    public class BankAccount
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string HolderName { get; set; }
        public string ExpiryDate { get; set; }

        public static bool Validate(BankAccount bankAccount)
        {
            // validate email
            var emailAttribute = new EmailAddressAttribute();
            if (bankAccount.Email == null || !emailAttribute.IsValid(bankAccount.Email))
            {
                return false;
            }

            // validate name
            if (bankAccount.Name == null || bankAccount.Name.Length < 2)
            {
                return false;
            }

            // validate surname
            if (bankAccount.Surname == null || bankAccount.Surname.Length < 2)
            {
                return false;
            }
            
            // validate phone number
            if (bankAccount.PhoneNumber == null || bankAccount.PhoneNumber.Length < 9)
            {
                foreach (char c in bankAccount.PhoneNumber)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
            }

            // validate county
            if (bankAccount.County == null || bankAccount.County.Length < 2)
            {
                return false;
            }

            // validate city
            if (bankAccount.City == null || bankAccount.City.Length < 2)
            {
                return false;
            }

            // validate address
            if (bankAccount.Address == null || bankAccount.Address.Length < 2)
            {
                return false;
            }

            // validate number
            if (bankAccount.Number == null || bankAccount.Number.Length < 16)
            {
                foreach (char c in bankAccount.Number)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
            }

            // validate holder name
            if (bankAccount.HolderName == null || bankAccount.HolderName.Length < 2)
            {
                return false;
            }

            // validate expiry date
            if (bankAccount.ExpiryDate == null || bankAccount.ExpiryDate.Length < 5)
            {
                return false;
            }

            return true;
        }
    }
}
