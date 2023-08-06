using System.Text;
using XSystem.Security.Cryptography;

namespace Mc2.CrudTest.DomainService.Extention
{
    public static class StringExtension
    {
        public static string ToHash(string firstName, string lastName, string date)
        {
            var myString = firstName.Trim() + lastName.Trim() + date.ToString().Trim();
            byte[] inputBytes = Encoding.ASCII.GetBytes(myString);
            byte[] hashBytes = new MD5CryptoServiceProvider().ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
