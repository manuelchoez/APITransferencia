using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Dominio.Entidades;
using Transferencia.Dominio.Repository;

namespace Transferencia.Infraestructura.Data
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly BddtransfContext _dadtransfContext;
        public MovimientoRepository(BddtransfContext dadtransfContext)
        {
            _dadtransfContext = dadtransfContext;
        }
        public async Task CrearMovimiento(Movimiento movimiento)
        {
            _dadtransfContext.Movimientos.Add(movimiento);
            await _dadtransfContext.SaveChangesAsync().ConfigureAwait(true);
        }        
    }
}
