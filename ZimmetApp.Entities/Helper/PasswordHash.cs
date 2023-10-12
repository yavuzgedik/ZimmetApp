using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZimmetApp.Entities.Helper
{
    public class PasswordHash
    {
        public static string MD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] passwordByte = Encoding.UTF8.GetBytes(text);
            passwordByte = md5.ComputeHash(passwordByte);

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < passwordByte.Length; i++)
            {
                sBuilder.Append(passwordByte[i].ToString("x2"));
            }

            string pass = sBuilder.ToString();

            return pass;
        }
    }

    
}
