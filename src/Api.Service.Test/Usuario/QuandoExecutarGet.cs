using System.Runtime.CompilerServices;
using Api.Domain.Dto.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoExecutarGet : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName="PossivelExecutarGet")]
        public async Task PossivelExecutarGet()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m=>m.Get(IdUsuario)).ReturnsAsync(useDto);
            _service  = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m=>m.Get(It.IsAny<Guid>()))
            .Returns(Task.FromResult((UseDto)null));
            _service = _serviceMock.Object;

            var _record  = await _service.Get(IdUsuario);
            Assert.Null(_record);
        }
    }
}