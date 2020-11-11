using Api.Domain.Dto;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Api.Domain.Interfaces.User;

namespace Api.Service.Test.Login
{
    public class QuandoExecultarFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName="PossivelExecultarFindByLogin")]
        public async Task PossivelExecultarFindByLogin()
        {
            var email = Faker.Internet.Email();
            var objetoRetorno = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "usuario logado com sucesso"
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m=>m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno);
            _service = _serviceMock.Object;

            var result  = await _service.FindByLogin(loginDto);

            Assert.NotNull(result);
        }

    }
}