using Api.Application.Controllers;
using Api.Domain.Dto.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitaGetAll
{
    public class RetornoGetAll
    {
        private UsersController _controller;

        [Fact(DisplayName="PossivelGetAll")]
        public async Task PossivelGetAll()
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

            _controller  = new UsersController(serviceMock.Object);

            var result = await _controller.GetAll();
            
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UseDto>;

            Assert.True(resultValue.Count()==3);
        }
    }
}