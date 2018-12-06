using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Service.Models.BaseModels
{
    public class ServiceException : ApplicationException
    {
        public ServiceException(string msg) : base(msg)
        {
        }
    }
}
