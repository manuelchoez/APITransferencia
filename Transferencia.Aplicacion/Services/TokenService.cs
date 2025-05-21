using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Aplicacion.Util;
using Transferencia.Dominio.Repository;

namespace Transferencia.Aplicacion.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public Response<string> GenerarToken(string username, string pass)
        {
            string token = string.Empty;
            if (username.Equals("payphone") && pass.Equals("pyphone2025*"))
            {
                token = _tokenRepository.GenerarToken(username, "Administrador");
            }
            else
            {
                return Response<string>.Ok(String.Empty,"Usuario o contraseña incorrectos");
            }
            return Response<string>.Ok(token, "Usuario Autenticado con exito");
        }
    }      
}
