using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace IFM2B10_2014_CS_Paper_A
{
    public static class Secrecy
    {
        public static string HashPassword(string password)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] byteArray = null;
            byteArray = algorithm.ComputeHash(Encoding.Default.GetBytes(password));
            string hashedPassword = "";
            for (int i = 0; i < byteArray.Length - 1; i++)
            {
                hashedPassword += byteArray[i].ToString("x2");
            }
            return hashedPassword;
        }
    }
}