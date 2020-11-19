using Api.Domain.Interfaces.Services.Municipio;
using System.Threading.Tasks;
using Xunit;
using Moq;
namespace Api.Service.Test.Municipio
{
    public class QuandoForExecultadoCreate : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock <IMunicipioService> _serviceMock;

        [Fact(DisplayName="PossivelRealizarCreate")]
        public async Task PossivelRealizarCreate ()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.Post(municipioDtoCreate))
            .ReturnsAsync(municipioDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(municipioDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicpio, result.CodIBGE);
            Assert.Equal(IdUf, result.UfId);
        }
    }
}