using System.Text;
using XSystem.Security.Cryptography;

namespace Mc2.CrudTest.DomainService.Extention
{
     public static class StringExtension
    {
        public static string ToHash(this string str ,string firstName ,string lastName , DateOnly date) 
        {
            var myString = firstName.Trim() + lastName.Trim() + date.ToString().Trim();
            byte[] inputBytes = Encoding.ASCII.GetBytes(myString);
            byte[] hashBytes = new MD5CryptoServiceProvider().ComputeHash(inputBytes); ;

            return Convert.ToHexString(hashBytes);
        }
    }
}
