using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Transferencia.API.Controllers;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Dominio.Entidades;
using Transferencia.Aplicacion.Util;

namespace Transferencia.Test
{
    public class BilleteraControllerTests
    {
        private Mock<IBilleteraService> _billeteraServiceMock;
        private BilleteraController _controller;

        [SetUp]
        public void Setup()
        {
            _billeteraServiceMock = new Mock<IBilleteraService>();
            _controller = new BilleteraController(_billeteraServiceMock.Object);
        }

        [Test]
        public async Task ObtenerPorId_ReturnsOk()
        {
            var billetera = new Billetera { Id = 1, Documentid = "1312677881" };
            var response = Response<Billetera?>.Ok(billetera, "Encontrado");

            _billeteraServiceMock
                .Setup(s => s.ObtenerPorIdAsync("123"))
                .ReturnsAsync(response);

            var result = await _controller.ObtenerPorId("1312677881");

            Assert.IsFalse(result.EsError);
            Assert.AreEqual("123", result.Result?.Documentid);
        }

        [Test]
        public async Task ObtenerLista_ReturnsLista()
        {
            var billeteras = new List<Billetera?> { new Billetera { Id = 1 } };
            var response = Response<List<Billetera?>>.Ok(billeteras, "Listado");

            _billeteraServiceMock
                .Setup(s => s.ObtenerListaAsync())
                .ReturnsAsync(response);

            var result = await _controller.ObtenerLista();

            Assert.IsFalse(result.EsError);
            Assert.AreEqual(1, result.Result.Count);
        }

        [Test]
        public async Task CrearBilletera_ReturnsSuccess()
        {
            var billetera = new Billetera { Id = 1, Documentid = "456" };
            var response = Response<bool>.Ok(true, "Creado");

            _billeteraServiceMock
                .Setup(s => s.CrearAsync(billetera))
                .ReturnsAsync(response);

            var result = await _controller.CrearBilletera(billetera);

            Assert.IsFalse(result.EsError);
            Assert.IsTrue(result.Result);
        }

        [Test]
        public async Task EliminarBilletera_ReturnsError()
        {
            var billetera = new Billetera { Id = 1 };
            var response = Response<bool>.Error(new Exception("No encontrada"));

            _billeteraServiceMock
                .Setup(s => s.EliminarAsync(billetera))
                .ReturnsAsync(response);

            var result = await _controller.EliminarBilletera(billetera);

            Assert.IsTrue(result.EsError);
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.Status);
        }
    }
}
