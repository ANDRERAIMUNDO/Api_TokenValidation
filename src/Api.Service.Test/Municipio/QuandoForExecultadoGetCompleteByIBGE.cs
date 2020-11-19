using Xunit;
using Moq;
using Api.Domain.Interfaces.Services.Municipio;
using System.Threading.Tasks;
namespace Api.Service.Test.Municipio
{
    public class QuandoForExecultadoGetCompleteByIBGE : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock <IMunicipioService> _serviceMock;

        [Fact(DisplayName="PossivelRealizarGetCompleteByIBGE")]
        public async Task PossivelRealizarGetCompleteByIBGE ()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.GetCompleteByIBGE(CodigoIBGEMunicpio))
            .ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMock.Object;

            var result  = await _service.GetCompleteByIBGE(CodigoIBGEMunicpio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicpio, result.CodIBGE);
            Assert.NotNull(result.Uf);
        }
    }
}