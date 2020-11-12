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
    public class RetornoCreate
    {
        private UsersController _controler;
        
        [Fact(DisplayName="PossivelCreate")]
        public async Task PossivelCreate()
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
            _controler = new UsersController(serviceMock.Object);

            Mock<IUrlHelper>url = new Mock<IUrlHelper>();
            url.Setup(x=>x.Link(It.IsAny<string>(), It.IsAny<object>()))
            .Returns("http://localhost:5000");
            _controler.Url = url.Object; 

            var useDtoCreate = new UseDtoCreate
            {
                Name = nome,
                Email = email
            };

            var result = await _controler.Post(useDtoCreate);
            
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as UseDtoCreateResult;

            Assert.NotNull(resultValue);
            Assert.Equal(useDtoCreate.Name, resultValue.Name);
            Assert.Equal(useDtoCreate.Email, resultValue.Email);
        }
    }
}