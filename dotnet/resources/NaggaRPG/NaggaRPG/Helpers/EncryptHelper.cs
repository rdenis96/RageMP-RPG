using System.Security.Cryptography;
using System.Text;

namespace NaggaRPG.Helpers
{
    public static class EncryptHelper
    {
        public static string ComputeSha512Hash(string rawData)
        {
            // Create a SHA512
            using (SHA512 sha = SHA512.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}