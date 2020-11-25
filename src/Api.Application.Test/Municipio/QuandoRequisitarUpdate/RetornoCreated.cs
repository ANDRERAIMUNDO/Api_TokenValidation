using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Municipio;
using Api.Application.Controllers;
namespace Api.Application.Test.Municipio.QuandoRequisitarUpdate
{
    public class RetornoCreated : ControllerBase
    {
        private MunicipiosController _controller;

        [Fact(DisplayName="UpdateRetorno")]
        public async Task UpdateRetorno()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m=>m.Put(It.IsAny<MunicipioDtoUpdate>()))
            .ReturnsAsync(
                new MunicipioDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    UpdateAt = DateTime.UtcNow
                }
            );
            _controller = new MunicipiosController(serviceMock.Object);

            var municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Nome = "São Paulo",
                CodIBGE =1
            };
            
            var result = await _controller.Put(municipioDtoUpdate);
            Assert.True(result is OkObjectResult);
        }
    }
}