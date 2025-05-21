using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Aplicacion.Util;
using Transferencia.Dominio.Dto;

namespace Transferencia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;
        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpPost]
        [Authorize]
        [Route("CrearMovimiento")]
        public async Task<Response<bool>> CrearMovimiento([FromBody] DtoMovimiento movimiento)
        {
            return await _movimientoService.CrearMovimiento(movimiento);
        }

    }
}
