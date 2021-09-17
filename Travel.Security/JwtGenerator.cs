using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Interfaces.Security;

namespace Travel.Security
{
    public class JwtGenerator : IJwtGenerator
    {
        public string CreateToken(string usuario)
        {
            var claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.NameId, usuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tr4v3lConvertT0k3n"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
