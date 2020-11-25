using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Municipio;
using Api.Application.Controllers;
namespace Api.Application.Test.Municipio.QuandoResquisitarGetCompleteByIBGE
{
    public class RetornoBadRequest
    {
        private MunicipiosController _controller;

         [Fact(DisplayName="BadResquestGetRetorno")]
         public async Task BadRequestGetRetorno()
         {
             var serviceMock = new Mock<IMunicipioService>();
             serviceMock.Setup(m=>m.GetCompleteByIBGE(It.IsAny<int>()))
             .ReturnsAsync(
                 new MunicipioDtoCompleto
                 {
                     Id = Guid.NewGuid(),
                     Nome = "São Paulo",
                 }
             );

             _controller = new MunicipiosController(serviceMock.Object);
             _controller.ModelState.AddModelError("Id", "Formato invalido");

             var result = await  _controller.GetCompleteByIBGE(1);
             Assert.True(result is BadRequestObjectResult);
         }
    }
}