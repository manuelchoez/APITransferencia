using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Aplicacion.Util;

namespace Transferencia.Aplicacion.Services.Interfaces
{
    public interface ITokenService
    {
       Response<string> GenerarToken(string username, string role);
    }
}
