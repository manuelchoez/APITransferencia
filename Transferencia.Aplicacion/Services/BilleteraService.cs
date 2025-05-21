using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Aplicacion.Util;
using Transferencia.Aplicacion.Validador;
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

        public async Task<Response<bool>> CrearAsync(Billetera billetera)
        {
            var (esValido, mensaje) = BilleteraValidator.Validar(billetera);
            if (!esValido)
                return Response<bool>.Ok(false, mensaje);

            billetera.CreateAt= DateTime.Now;
            Billetera? respuesta = await _billeteraRepository.ObtenerPorIdAsync(billetera.Documentid);
            if (respuesta == null)
            {
                await _billeteraRepository.CrearAsync(billetera);
                return Response<bool>.Ok(true, Constantes.ConstantesTransferenciaApi.MsjBilleteraCreada);
            }
            else
            {
                return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjBilleteraDuplicada);
            }

            
            
        }

        public async Task<Response<bool>> EliminarAsync(Billetera billetera)
        {
            var (esValido, mensaje) = BilleteraValidator.Validar(billetera);
            if (!esValido)
                return Response<bool>.Ok(false, mensaje);

            Billetera? b = await  _billeteraRepository.ObtenerPorIdAsync(billetera.Documentid);
            if (b != null) {
                await _billeteraRepository.EliminarAsync(b);
                return Response<bool>.Ok(true, Constantes.ConstantesTransferenciaApi.MsjBilleteraEliminada);
            }
            else
            {
                return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjBilleteraNoEncontrada);
            }
        }

        public async Task<Response<bool>> GuardarAsync(Billetera billetera)
        {
            var (esValido, mensaje) = BilleteraValidator.Validar(billetera);
            if (!esValido)
                return Response<bool>.Ok(false, mensaje);
            
            Billetera? b = await _billeteraRepository.ObtenerPorIdAsync(billetera.Documentid);
            if (b != null)
            {
                b.Balance = billetera.Balance;
                b.Name = billetera.Name;
                b.UpdateAt = DateTime.Now;
                await _billeteraRepository.GuardarAsync(b);
                return Response<bool>.Ok(true, Constantes.ConstantesTransferenciaApi.MsjBilleteraActualizada);
            }
            else
            {
                return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjBilleteraNoEncontrada);
            }


        }

        public async Task<Response<List<Billetera?>>> ObtenerListaAsync()
        {
            List<Billetera?> respuesta = await _billeteraRepository.ObtenerListaAsync();
            return Response<List<Billetera?>>.Ok(respuesta, Constantes.ConstantesTransferenciaApi.MsjListaBilleteras);
        }

        public async Task<Response<Billetera?>> ObtenerPorIdAsync(string documentId)
        {
            Billetera? respuesta = await _billeteraRepository.ObtenerPorIdAsync(documentId);
            return Response<Billetera?>.Ok(respuesta, Constantes.ConstantesTransferenciaApi.MsjBilletera);
        }
    }
}
