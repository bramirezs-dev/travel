using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Application.Features.Token.Querys.CreateToken;

namespace Travel.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateTokenQuery createTokenQuery ) {

            return Ok(await Mediator.Send(createTokenQuery));
        }
    }
}
