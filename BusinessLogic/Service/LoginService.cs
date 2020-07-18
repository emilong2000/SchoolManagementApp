using BusinessLogic.IService;
using DataAccess;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class LoginService : ILoginService
    {
        public bool Login(Login login)
        {
            UserLogin userLogin = new UserLogin();
            var result = userLogin.IsValidUser(login);
            return result;
        }
    }
}
