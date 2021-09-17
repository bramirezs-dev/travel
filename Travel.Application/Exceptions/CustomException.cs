using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Exceptions
{
    public class CustomException<T>:Exception
    {
        public T Response { get; set; }
        public HttpStatusCode StatusHttpCode { get; set; }
    }
}
