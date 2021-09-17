using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Wrappers
{
    public class ResponseSuccessful<T>
    {
        public bool RequestResult { get; set; }
        public T Data { get; set; }
    }
}
