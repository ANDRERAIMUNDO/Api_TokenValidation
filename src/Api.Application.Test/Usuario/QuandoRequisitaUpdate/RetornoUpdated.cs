using Api.Application.Controllers;
using Api.Domain.Dto.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitaUpdate
{
    public class RetornoUpdated
    {
        private UsersController _controller;

        [Fact(DisplayName="PossivelRetornoUpdated")]
        public async Task PossivelRetornoUpdated()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m=>m.Put(It.IsAny<UseDtoUpdate>()))
            .ReturnsAsync(
                new UseDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    UpdateAt = DateTime.UtcNow
                }
            );
            _controller = new UsersController(serviceMock.Object);

            var useDtoUpdate = new UseDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email
            };

            var result = await _controller.Put(useDtoUpdate);

            Assert.True(result is OkObjectResult);

            UseDtoUpdateResult useDtoUpdateResult = ((OkObjectResult)result).Value as UseDtoUpdateResult;

            Assert.NotNull(useDtoUpdateResult);
            Assert.Equal(useDtoUpdate.Name, useDtoUpdateResult.Name);
            Assert.Equal(useDtoUpdate.Email, useDtoUpdateResult.Email);
        }
    }
}