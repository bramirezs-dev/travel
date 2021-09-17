using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Interfaces.Security
{
    public interface IJwtGenerator
    {
        string CreateToken(string usuario);
    }
}
