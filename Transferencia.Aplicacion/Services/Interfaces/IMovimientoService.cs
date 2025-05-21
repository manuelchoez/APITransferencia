using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transferencia.Aplicacion.Util;
using Transferencia.Dominio.Dto;
using Transferencia.Dominio.Entidades;

namespace Transferencia.Aplicacion.Services.Interfaces
{
    public interface IMovimientoService
    {
        Task<Response<bool>> CrearMovimiento(DtoMovimiento movimiento);
    }
}
