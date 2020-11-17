using System.Threading.Tasks;
using Xunit;
using Moq;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Test.Usuario
{
    public class QuandoAdicionarCreate : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService>  _serviceMock;

        [Fact(DisplayName="PossivelExecutarMetodoCreate")]
        public async Task PossivelExecutarMetodoCreate()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(useDtoCreate)).ReturnsAsync(useDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(useDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
        }
    }
}