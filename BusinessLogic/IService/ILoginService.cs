using DomainModel.Models;
using DomainModel.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface ILoginService
    {
        bool Login(Login login);
    }
}
