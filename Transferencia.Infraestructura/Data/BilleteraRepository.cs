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
    public class BilleteraRepository : IBilleteraRepository
    {
        private readonly BddtransfContext _dadtransfContext;

        public BilleteraRepository(BddtransfContext dadtransfContext)
        {
            _dadtransfContext = dadtransfContext;
        }

        public async Task CrearAsync(Billetera billetera)
        {
            _dadtransfContext.Billeteras.Add(billetera);
            await _dadtransfContext.SaveChangesAsync().ConfigureAwait(true);
        }

        public async Task EliminarAsync(Billetera billetera)
        {
            _dadtransfContext.Billeteras.Remove(billetera);
            await _dadtransfContext.SaveChangesAsync().ConfigureAwait(true);
        }

        public async Task GuardarAsync(Billetera billetera)
        {
            _dadtransfContext.Entry(billetera).State = EntityState.Modified;            
            await _dadtransfContext.SaveChangesAsync().ConfigureAwait(true);            
        }

        public async Task<List<Billetera?>> ObtenerListaAsync()
        {
            return await _dadtransfContext.Billeteras.Include(b => b.Movimientos).ToListAsync();
        }

        public async Task<Billetera?> ObtenerPorIdAsync(string documentoId)
        {
            return await _dadtransfContext.Billeteras.FirstOrDefaultAsync(b => b.Documentid == documentoId);
        }
    }
}
