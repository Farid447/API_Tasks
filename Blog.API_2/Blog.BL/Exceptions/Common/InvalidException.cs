using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BL.Exceptions.Common
{
    internal class InvalidException<T> : Exception, IBaseException
    {
        public int Code => StatusCodes.Status400BadRequest;
        public string ErrorMessage { get; }

        public InvalidException() : base(typeof(T).Name + " is invalid")
        {
            ErrorMessage = typeof(T).Name + " is invalid";
        }
        public InvalidException(string msg) : base(msg)
        {
            ErrorMessage = msg;
        }
    }
}
