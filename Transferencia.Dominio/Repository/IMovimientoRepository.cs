using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Dominio.Entidades;

namespace Transferencia.Dominio.Repository
{
    public interface IMovimientoRepository
    {        
        Task CrearMovimiento(Movimiento movimiento);        
    }
}
