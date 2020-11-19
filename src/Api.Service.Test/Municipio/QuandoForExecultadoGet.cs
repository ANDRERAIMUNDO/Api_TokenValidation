using System;
using Xunit;
using Moq;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Dto.Municipio;
using System.Threading.Tasks;
namespace Api.Service.Test.Municipio
{
    public class QuandoForExecultadoGet : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock <IMunicipioService> _serviceMock;

        [Fact(DisplayName="PossivelRealizarGet")]
        public async Task PossivelRealizarGet ()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.Get(IdMunicipio))
            .ReturnsAsync(municipioDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicpio, result.CodIBGE);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.Get(It.IsAny<Guid>()))
            .Returns(Task.FromResult((MunicipioDto)null));
            _service = _serviceMock.Object;

            var record = await _service.Get(IdMunicipio);
            Assert.Null(record);
        }
    }
}