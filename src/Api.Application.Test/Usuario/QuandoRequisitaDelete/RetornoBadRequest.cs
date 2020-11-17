using System;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace Api.Application.Test.Usuario.QuandoRequisitaDelete
{
    public class RetornoBadRequest
    {
        UsersController _controller;

        [Fact(DisplayName="PossivelDeleted")]
        public async Task PossivelDeleted()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m=>m.Delete(It.IsAny<Guid>()))
            .ReturnsAsync(false);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato invalido");

            var result = await _controller.Delete(default(Guid));

            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);

        }
    }
}