using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string StatusCode { get; set; }
    }
}
