using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Transferencia.API.Controllers;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Aplicacion.Util;
using Transferencia.Dominio.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Transferencia.Test
{
    public class MovimientoControllerTests
    {
        private Mock<IMovimientoService> _movimientoServiceMock;
        private MovimientoController _controller;

        [SetUp]
        public void Setup()
        {
            _movimientoServiceMock = new Mock<IMovimientoService>();
            _controller = new MovimientoController(_movimientoServiceMock.Object);
        }

        [Test]
        public async Task CrearMovimiento_ReturnsSuccess()
        {
            var dto = new DtoMovimiento { DocumentId = "1312677882", Amount = 100, Type = "Credito" };
            var response = Response<bool>.Ok(true, "Movimiento creado");

            _movimientoServiceMock
                .Setup(s => s.CrearMovimiento(dto))
                .ReturnsAsync(response);

            var result = await _controller.CrearMovimiento(dto);

            Assert.IsFalse(result.EsError);
            Assert.IsTrue(result.Result);
        }

        [Test]
        public async Task CrearMovimiento_ReturnsError()
        {
            var dto = new DtoMovimiento { DocumentId = "1312677882", Amount = 50, Type = "Debito" };
            var response = Response<bool>.Error(new Exception("Fondos insuficientes"));

            _movimientoServiceMock
                .Setup(s => s.CrearMovimiento(dto))
                .ReturnsAsync(response);

            var result = await _controller.CrearMovimiento(dto);

            Assert.IsTrue(result.EsError);
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.Status);
        }
    }
}
