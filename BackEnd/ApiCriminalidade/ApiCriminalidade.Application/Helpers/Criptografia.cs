﻿using System.Security.Cryptography;
using System.Text;

namespace ApiCriminalidade.Application.Helpers
{
    public static class Criptografia
    {
        public static string GerarHash(this string senha)
        {
            var hash = SHA1.Create();

            var encode = new ASCIIEncoding();
            var array = encode.GetBytes(senha);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array) 
            {
                strHexa.Append(item.ToString("X2"));
            }
            return strHexa.ToString();
            
        }
    }
}