using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia.Dominio.Repository
{
    public  interface ITokenRepository
    {
       string GenerarToken(string username, string role);
    }
}
