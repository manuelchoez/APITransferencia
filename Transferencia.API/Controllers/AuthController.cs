using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Aplicacion.Util;

namespace Transferencia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("GenerarToken")]
        public Response<string> GenerarToken(string username, string pass)
        {
            return _tokenService.GenerarToken(username, pass);
        }
    }
}
