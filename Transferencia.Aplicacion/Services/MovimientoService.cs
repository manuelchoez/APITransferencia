using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Aplicacion.Util;
using Transferencia.Dominio.Dto;
using Transferencia.Dominio.Entidades;
using Transferencia.Dominio.Repository;

namespace Transferencia.Aplicacion.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IBilleteraRepository _billeteraRepository;

        public MovimientoService(IMovimientoRepository movimientoRepository, IBilleteraRepository billeteraRepository)
        {
            _movimientoRepository = movimientoRepository;
            _billeteraRepository = billeteraRepository;
        }

        public async Task<Response<bool>> CrearMovimiento(DtoMovimiento movimiento)
        {
            if (movimiento == null)
            {
                return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjValiacionDatos);
            }
            if (string.IsNullOrEmpty(movimiento.DocumentId))
            {
                return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjValiacionDocumentId);
            }
            if (movimiento.Amount ==0 || movimiento.Amount<0)
            {
                return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjValiacionMontoIncorrecto);
            }
            if (string.IsNullOrEmpty(movimiento.Type) || (!movimiento.Type.Contains("Debito") && !movimiento.Type.Contains("Credito")))
            {
                return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjValiacionType);
            }
           


            Billetera? b = await _billeteraRepository.ObtenerPorIdAsync(movimiento.DocumentId);
            if (b == null)
            {
                return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjBilleteraNoEncontrada);
            }
            else
            {
                if (movimiento.Type.Contains("Debito") && b.Balance < movimiento.Amount)
                {
                    return Response<bool>.Ok(false, Constantes.ConstantesTransferenciaApi.MsjBilleteraSinFondos);
                }

                switch (movimiento.Type)
                {
                    case "Debito":
                        b.Balance -= movimiento.Amount;
                        break;
                    case "Credito":
                        b.Balance += movimiento.Amount;
                        break;
                    default:
                        break;
                }

                Movimiento movimientoCreado = new Movimiento
                {                   
                    WalletId = b.Id,
                    Amount = movimiento.Amount,
                    Type = movimiento.Type,
                    CreateAt = DateTime.Now
                };

                await _movimientoRepository.CrearMovimiento(movimientoCreado);
                await _billeteraRepository.GuardarAsync(b);
                return Response<bool>.Ok(true, Constantes.ConstantesTransferenciaApi.MsjMovimientoCreado);
            }
        }
    }
}
