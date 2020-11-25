using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Cep;
using Api.Application.Controllers;
namespace Api.Application.Test.Cep.QuandoRequisitarDelete
{
    public class RetornoBadResquest : ControllerBase
    {
        private CepsController _controller;
        
        [Fact(DisplayName="BadRequestRetorno")]
        public async Task BadRequestRetorno()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m=> m.Delete(It.IsAny<Guid>()))
            .ReturnsAsync(true);

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato invalido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}