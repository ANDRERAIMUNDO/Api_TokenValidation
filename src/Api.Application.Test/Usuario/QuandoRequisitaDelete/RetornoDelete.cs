using System;
using Api.Application.Controllers;
using Api.Domain.Dto.User;
using Api.Domain.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace Api.Application.Test.Usuario.QuandoRequisitaDelete
{
    public class RetornoDelete
    {
        private UsersController _controller;

        [Fact(DisplayName="PossivelDeleted")]
        public async Task PossivelDeleted()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m=>m.Delete(It.IsAny<Guid>()))
            .ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());

            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;

            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }

    }
}