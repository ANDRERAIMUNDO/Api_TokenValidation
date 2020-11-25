using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Cep;
using Api.Application.Controllers;
namespace Api.Application.Test.Cep.QuandoRequisitarCreate
{
    public class RetornoCreated : ControllerBase
    {
        private CepsController _controller;
        
        [Fact(DisplayName="CreatedRetorno")]
        public async Task CreatedRetorno()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m =>m.Post(It.IsAny<CepDtoCreate>()))
            .ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de rua",
                    CreateAt = DateTime.UtcNow
                }
            ); 
            _controller = new CepsController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x =>x.Link(It.IsAny<string>(), It.IsAny<object>()))
            .Returns("http://localhost:5000");
            
            _controller.Url = url.Object;
            var cepCreateDto = new CepDtoCreate
            {
                Logradouro = "Teste de rua",
                Numero = ""
            };
            var result = await _controller.Post(cepCreateDto);
            Assert.True(result is CreatedResult);
        }
    }
}