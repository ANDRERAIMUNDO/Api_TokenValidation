using System;
using Api.Domain.Interfaces.Services.Cep;
using System.Threading.Tasks;
using Xunit;
using Moq;
namespace Api.Service.Test.Cep
{
    public class QuandoForExecultadoDelete : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName="ExecultarDelete")]
        public async Task ExecultaDelete()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m=>m.Delete(IdCep))
            .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdCep);
            Assert.True(deletado);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m=>m.Delete(It.IsAny<Guid>()))
            .ReturnsAsync(false);
            _service = _serviceMock.Object;
            
            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}