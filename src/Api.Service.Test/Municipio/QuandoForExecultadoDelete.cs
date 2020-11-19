using System;
using Xunit;
using Moq;
using Api.Domain.Interfaces.Services.Municipio;
using System.Threading.Tasks;
namespace Api.Service.Test.Municipio
{
    public class QuandoForExecultadoDelete : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock <IMunicipioService> _serviceMock;

        [Fact(DisplayName="PossivelRealizarDelete")]
        public async Task PossivelRealizarDelete ()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.Delete(IdMunicipio))
            .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdMunicipio);
            Assert.True(deletado);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
            .ReturnsAsync(false);

            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}