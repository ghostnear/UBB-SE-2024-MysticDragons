using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.PaymentsAndBillings.Services
{
    class DataEncryptionService
    {
        static string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static string shuffleAlphabet()
        {
            string shuffled = "";
            int lengthOfAlphabet = alphabet.Length;
            Random rand = new Random();
            char randomCharacter;
            string copyOfAlphabet = alphabet;
            while (shuffled.Length < lengthOfAlphabet)
            {
                if (copyOfAlphabet.Length > 1)
                    randomCharacter = copyOfAlphabet[rand.Next(copyOfAlphabet.Length)];
                else
                    randomCharacter = copyOfAlphabet[0];
                shuffled += randomCharacter;
                copyOfAlphabet = copyOfAlphabet.Replace(randomCharacter.ToString(), "");
            }
            return shuffled;
        }

        public static Dictionary<string, string> Encrypt(string data)
        {
            string key = shuffleAlphabet();
            string encryptedData = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (char.IsLower(data[i]))
                {
                    encryptedData += key[data[i] - 'a'];
                }
                else if (char.IsUpper(data[i]))
                {
                    encryptedData += key[data[i] - 'A' + 26];
                }
                else
                {
                    encryptedData += data[i];
                }
            }
            Dictionary<string, string> result = new Dictionary<string, string>
            {
                { "data", encryptedData },
                { "key", key }
            };
            return result;
        }

        public static string Decrypt(string data, string key)
        {
            string decryptedData = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (char.IsLetter(data[i]))
                {
                    int index = key.IndexOf(data[i]);
                    decryptedData += alphabet[index];
                }
                else
                {
                    decryptedData += data[i];
                }
            }
            return decryptedData;
        }
    }
}
