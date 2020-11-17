using Api.Application.Controllers;
using Api.Domain.Dto.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System;

namespace Api.Application.Test.Usuario.QuandoRequisitaGet
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName="ErroRetornoBadRequest")]
        public async Task ErroRetornoBadRequest()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m=>m.Get(It.IsAny<Guid>()))
            .ReturnsAsync(
                new UseDto
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato errado");

            var result = await _controller.Get(Guid.NewGuid());

            Assert.True(result is BadRequestObjectResult);
        }
    }
}