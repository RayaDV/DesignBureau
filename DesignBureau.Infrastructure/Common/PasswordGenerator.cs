using System.Security.Cryptography;
using System.Text;

namespace DesignBureau.Infrastructure.Common
{
    public static class PasswordGenerator
    {
        public static string Generate()
        {
            var password = new StringBuilder();
            var random = new Random();

            while (password.Length < 12)
            {
                password.Append((char)random.Next(97, 122));
                password.Append((char)random.Next(65, 90));
                password.Append((char)random.Next(48, 57));
            }

            return password.ToString().Trim();
        }

        public static string GetHash(string input)
        {
            var passHash = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            foreach (byte b in passHash)
                sb.Append(b.ToString());

            return sb.ToString();
        }
    }
}
