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
    public class RetornoGet
    {
        private UsersController _controller;

        [Fact(DisplayName="PossivelGet")]
        public async Task PossivelGet()
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
            });
            _controller  = new UsersController(serviceMock.Object);
            
            var result = await _controller.Get(Guid.NewGuid());

            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UseDto;

            Assert.NotNull(resultValue);
            Assert.Equal(nome, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
        }
    }
}