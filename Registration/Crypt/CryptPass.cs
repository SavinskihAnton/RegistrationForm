﻿using System;
using System.Text;

namespace Registration.Crypt
{
    public class CryptPass
    {
        public string Encode(string password)
        {
            try
            {
                byte[] encByte = new byte[password.Length];
                encByte=Encoding.UTF8.GetBytes(password);
                string encryptPass=Convert.ToBase64String(encByte);
                return encryptPass;
            }
            catch(Exception e)
            {
                throw new Exception("Error in encode "+e.Message);
            }
        }
    }
}
