using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Wrappers
{
    public class ResponseIncorrect<T>
    {
        public bool RequestResult { get; set; }
        public T Errors { get; set; }
    }
}
