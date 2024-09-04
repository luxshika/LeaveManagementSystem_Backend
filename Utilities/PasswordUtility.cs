using System.Security.Cryptography;
using System.Text;

namespace LeaveManagementSystem_Backend.Utilities
{
    public class PasswordUtility
    {
        private static readonly char[] PasswordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static readonly Random Random = new Random();

        // Method to generate an auto password
        public static string GenerateAutoPassword(int length = 12)
        {
            return new string(Enumerable.Repeat(PasswordChars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        // Method to hash the password
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
