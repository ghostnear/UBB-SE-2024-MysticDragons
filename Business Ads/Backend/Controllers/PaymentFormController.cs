using Backend.PaymentsAndBillings.Models;
using Backend.PaymentsAndBillings.Repositories;
using System.Net;
using System.Net.Mail;

namespace Backend.PaymentsAndBillings.Controllers
{
    public class PaymentFormController(AccountRepository repoAccount, ProductRepository repoProduct)
    {
        private readonly AccountRepository _accountRepository = repoAccount;
        private readonly ProductRepository _productRepository = repoProduct;

        public Task SendPaymentConfirmationMailAsync()
        {
            var sender = "osvathrobert03@gmail.com";
            var receiver = _accountRepository.BankAccount.Email;
            var password = "daes ndml ukpj qvuj";

            var product = _productRepository.Product;
            var subject = "Payment Confirmation For " + product.Name;
            var message = "Description: " + product.Description + "\nPrice: " + product.Price;

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(sender, password),
                EnableSsl = true
            };

            var mail = new MailMessage(
                from: sender,
                to: receiver,
                subject: subject,
                body: message
            );
            return client.SendMailAsync(mail);
        }

        public ProductMock getProduct()
        {
            return _productRepository.Product;
        }
    }
}
