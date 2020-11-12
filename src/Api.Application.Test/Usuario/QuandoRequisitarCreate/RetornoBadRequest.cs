using Api.Application.Controllers;
using Api.Domain.Dto.User;
using Api.Domain.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarCreate
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName="ErroCreated")]
        public async Task ErroCreated()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m=>m.Post(It.IsAny<UseDtoCreate>()))
            .ReturnsAsync(
                new UseDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Campo obrigatorio");

            Mock<IUrlHelper>url = new Mock<IUrlHelper>();
            url.Setup(x=>x.Link(It.IsAny<string>(), It.IsAny<object>()))
            .Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var useDtoCreated  = new UseDtoCreate
            {
                Name = nome,
                Email = email
            };

            var result = await _controller.Post(useDtoCreated);

            Assert.True(result is BadRequestObjectResult);
        }
    }
}