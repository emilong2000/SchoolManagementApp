using DomainModel.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserLogin
    {
        private readonly ApplicationDbContext _context;
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public UserLogin()
        {
            _context = new ApplicationDbContext();
        }
       
        public  bool IsValidUser(Login login)
        {

            try
            {
                var checkuser = _context.Students.Where(x => x.Email == login.Email).FirstOrDefault();
                if(checkuser != null)
                {
                    string savedPasswordHash = checkuser.Password;
                    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                    /* Get the salt */
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    /* Compute the hash on the password the user entered */
                    var pbkdf2 = new Rfc2898DeriveBytes(login.Password, salt, 100000);
                    byte[] hash = pbkdf2.GetBytes(20);
                    /* Compare the results */
                    for (int i = 0; i < 20; i++)
                        if (hashBytes[i + 16] != hash[i])
                            throw new UnauthorizedAccessException();
                    
                }
                return true;
                /* Extract the bytes */

            }
            catch (Exception ex)
            {

                _logger.Error(ex);
                return false;
            }
        }
      
    }
}
