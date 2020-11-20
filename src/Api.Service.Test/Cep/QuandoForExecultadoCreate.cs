using Api.Domain.Interfaces.Services.Cep;
using System.Threading.Tasks;
using Xunit;
using Moq;
namespace Api.Service.Test.Cep
{
    public class QuandoForExecultadoCreate : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName="ExecultarCreate")]
        public async Task ExecultarCreate()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m=>m.Post(cepDtoCreate))
            .ReturnsAsync(cepDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cepDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CepOriginal,result.Cep);
            Assert.Equal(LogradouroOriginal, result.Logradouro);
            Assert.Equal(NumeroOriginal, result.Numero);
        }

    }
}