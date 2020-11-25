using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Cep;
using Api.Application.Controllers;
namespace Api.Application.Test.Cep.QuandoRequisitarUpdate
{
    public class RetornoOk : ControllerBase
    {
        CepsController _controller;
        [Fact(DisplayName="OkRetorno")]
        public async Task OkRetorno()
        {
             var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>()))
            .ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de rua",
                    UpdateAt = DateTime.UtcNow
                }
            );
            _controller = new CepsController(serviceMock.Object);

            var cepDtoUpdate = new CepDtoUpdate
            {
                Logradouro = "Teste de rua",
                Cep = "1033444"
            };
            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is OkObjectResult);
        }
    }
}