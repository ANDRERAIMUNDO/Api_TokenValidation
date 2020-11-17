using Api.Application.Controllers;
using Api.Domain.Dto.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitaGetAll
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName="GetAllBadRequest")]
        public async Task GetAllBadRequest()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m=>m.GetAll())
            .ReturnsAsync(
                new List<UseDto>
                {
                    new UseDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    },
                    new UseDto
                    {
                         Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    },
                    new UseDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    }
                }
            );
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato invalido");

            var result = await _controller.GetAll();

            Assert.True(result is BadRequestObjectResult);
        }
    }
}