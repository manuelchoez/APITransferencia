using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Aplicacion.Util;
using Transferencia.Dominio.Entidades;

namespace Transferencia.Aplicacion.Services.Interfaces
{
    public interface IBilleteraService
    {
        Task<Response<Billetera?>> ObtenerPorIdAsync(string documentId);
        Task<Response<List<Billetera?>>> ObtenerListaAsync();
        Task<Response<bool>> CrearAsync(Billetera billetera);
        Task<Response<bool>> GuardarAsync(Billetera billetera);
        Task<Response<bool>> EliminarAsync(Billetera billetera);
    }
}
