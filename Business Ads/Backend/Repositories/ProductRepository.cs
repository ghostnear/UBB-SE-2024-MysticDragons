using Backend.Models;
using Backend.Services;

namespace Backend.Repositories
{
    public class ProductRepository
    {
        private ProductMock _product;
        private string _nameKey;
        private string _descriptionKey;
        private string _priceKey;
        private string _imageKey;

        public ProductMock Product
        {
            get
            {
                string decryptedName = DataEncryptionService.Decrypt(_product.Name, _nameKey);
                string decryptedDescription = DataEncryptionService.Decrypt(_product.Description, _descriptionKey);
                string decryptedPrice = DataEncryptionService.Decrypt(_product.Price, _priceKey);
                string decryptedImage = DataEncryptionService.Decrypt(_product.Image, _imageKey);
                return new ProductMock
                {
                    Name = decryptedName,
                    Description = decryptedDescription,
                    Price = decryptedPrice,
                    Image = decryptedImage
                };
            }
            set
            {
                Dictionary<string, string> encryptedNameKVPair = DataEncryptionService.Encrypt(value.Name);
                string encryptedName = encryptedNameKVPair["data"];
                _nameKey = encryptedNameKVPair["key"];
                Dictionary<string, string> encryptedDescriptionKVPair = DataEncryptionService.Encrypt(value.Description);
                string encryptedDescription = encryptedDescriptionKVPair["data"];
                _descriptionKey = encryptedDescriptionKVPair["key"];
                Dictionary<string, string> encryptedPriceKVPair = DataEncryptionService.Encrypt(value.Price);
                string encryptedPrice = encryptedPriceKVPair["data"];
                _priceKey = encryptedPriceKVPair["key"];
                Dictionary<string, string> encryptedImageKVPair = DataEncryptionService.Encrypt(value.Image);
                string encryptedImage = encryptedImageKVPair["data"];
                _imageKey = encryptedImageKVPair["key"];
                _product = new ProductMock
                {
                    Name = encryptedName,
                    Description = encryptedDescription,
                    Price = encryptedPrice,
                    Image = encryptedImage
                };
            }
        }

        public ProductRepository(ProductMock product)
        {
            Product = product;
        }
    }
}
