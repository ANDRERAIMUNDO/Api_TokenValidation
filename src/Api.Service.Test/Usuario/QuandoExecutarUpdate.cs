using Api.Domain.Interfaces.User;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoExecutarUpdate : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName="PossivelRealizarUpdate")]
        public async Task PossivelRealizarUpdate()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m=>m.Post(useDtoCreate)).ReturnsAsync(useDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(useDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m=>m.Put(useDtoUpdate)).ReturnsAsync(useDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(useDtoUpdate);

            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
        }
    }
}