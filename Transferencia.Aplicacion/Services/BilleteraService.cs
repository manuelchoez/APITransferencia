using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Dominio.Entidades;
using Transferencia.Dominio.Repository;

namespace Transferencia.Aplicacion.Services
{
    public class BilleteraService : IBilleteraService
    {
        private readonly IBilleteraRepository _billeteraRepository;

        public BilleteraService(IBilleteraRepository billeteraRepository)
        {
            _billeteraRepository = billeteraRepository;
        }

        public async Task CrearAsync(Billetera billetera)
        {
            await _billeteraRepository.CrearAsync(billetera);
        }

        public async Task EliminarAsync(Billetera billetera)
        {
            Billetera? b = await  _billeteraRepository.ObtenerPorIdAsync(billetera.Documentid);
            if (b != null) {
                await _billeteraRepository.EliminarAsync(b);
            }
        }

        public async Task GuardarAsync(Billetera billetera)
        {
            await _billeteraRepository.GuardarAsync(billetera);
        }

        public async Task<List<Billetera?>> ObtenerListaAsync()
        {
            return await _billeteraRepository.ObtenerListaAsync();
        }

        public async Task<Billetera?> ObtenerPorIdAsync(string documentId)
        {
            return await _billeteraRepository.ObtenerPorIdAsync(documentId);
        }
    }
}
