using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Dominio.Entidades;

namespace Transferencia.Dominio.Repository
{
    public interface IBilleteraRepository
    {
        Task<Billetera?> ObtenerPorIdAsync(string documentId);
        Task<List<Billetera?>> ObtenerListaAsync();
        Task CrearAsync(Billetera billetera);
        Task GuardarAsync(Billetera billetera);
        Task EliminarAsync(Billetera billetera);
    }
}
