using Api.Domain.Interfaces.Services.Municipio;
using System.Threading.Tasks;
using Xunit;
using Moq;
namespace Api.Service.Test.Municipio
{
    public class QuandoForExecultadoUpdate : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock <IMunicipioService> _serviceMock;

        [Fact(DisplayName="PossivelRealizarUpdate")]
        public async Task PossivelRealizarUpdate ()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.Put(municipioDtoUpdate))
            .ReturnsAsync(municipioDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(municipioDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeMunicipioAlterado, resultUpdate.Nome);
            Assert.Equal(CodigoIBGEMunicipioAlterado, resultUpdate.CodIBGE);
            Assert.Equal(IdUf, resultUpdate.UfId);
        }
    }
}