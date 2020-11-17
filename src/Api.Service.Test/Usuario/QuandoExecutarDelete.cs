using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoExecutarDelete : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName="PossivelExecutarDelete")]
        public async Task PossivelExecutarDelete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m=>m.Delete(IdUsuario))
            .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado  = await _service.Delete(IdUsuario);

            Assert.True(deletado);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m=>m.Delete(It.IsAny<Guid>()))
            .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}