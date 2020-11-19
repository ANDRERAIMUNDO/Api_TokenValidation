using Xunit;
using Moq;
using Api.Domain.Interfaces.Services.Municipio;
using System.Threading.Tasks;
namespace Api.Service.Test.Municipio
{
    public class QuandoForExecultadoGetCompleteById : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock <IMunicipioService> _serviceMock;

        [Fact(DisplayName="PossivelRealizarGetCompleteById")]
        public async Task PossivelRealizarGetCompleteById ()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.GetCompleteById(IdMunicipio))
            .ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMock.Object;

            var result  = await _service.GetCompleteById(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicpio, result.CodIBGE);
            Assert.NotNull(result.Uf);
        }
    }
}