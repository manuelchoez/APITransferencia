using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Aplicacion.Util;
using Transferencia.Dominio.Entidades;

namespace Transferencia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleteraController : ControllerBase
    {
        private readonly IBilleteraService _billeteraService;

        public BilleteraController(IBilleteraService billeteraService)
        {
            _billeteraService = billeteraService;
        }

        [HttpGet]
        [Authorize]
        [Route("ObtenerLista")]        
        public async Task<Response<List<Billetera?>>> ObtenerLista()
        {
            return await _billeteraService.ObtenerListaAsync();            
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ObtenerPorId")]
        public async Task<Response<Billetera?>> ObtenerPorId(string documentId)
        {
            return await _billeteraService.ObtenerPorIdAsync(documentId);
        }

        [HttpPost]
        [Authorize]
        [Route("CrearBilletera")]
        public async Task<Response<bool>> CrearBilletera([FromBody] Billetera billetera)
        {
            return await _billeteraService.CrearAsync(billetera);
        }

        [HttpPut]
        [Authorize]
        [Route("ActualizarBilletera")]
        public async Task<Response<bool>> ActualizarBilletera([FromBody] Billetera billetera)
        {
            return await _billeteraService.GuardarAsync(billetera);
        }

        [HttpDelete]
        [Authorize]
        [Route("EliminarBilletera")]
        public async Task<Response<bool>> EliminarBilletera([FromBody] Billetera billetera)
        {
            return await _billeteraService.EliminarAsync(billetera);
        }

    }
}   
