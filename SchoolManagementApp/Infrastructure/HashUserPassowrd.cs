using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SchoolManagementApp.Infrastructure
{
    public class HashUserPassowrd
    {
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public static string Hash(string password)
        {
            try
            {
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);

                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                return savedPasswordHash;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
        
    }
}