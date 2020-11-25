using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Municipio;
using Api.Application.Controllers;
namespace Api.Application.Test.Municipio.QuandoRequisitarDelete
{
    public class RetornoBadRequest : ControllerBase
    {
          private MunicipiosController _controller;

         [Fact(DisplayName="BadResquestDeleteRetorno")]
         public async Task BadRequestDeleteRetorno()
         {
             var serviceMock = new Mock<IMunicipioService>();
             serviceMock.Setup(m=>m.Delete(It.IsAny<Guid>()))
             .ReturnsAsync(true);

             _controller = new MunicipiosController(serviceMock.Object);
             _controller.ModelState.AddModelError("Id", "Formato invalido");

             var result = await  _controller.Delete(Guid.NewGuid());
             Assert.True(result is BadRequestObjectResult);
         }
    }
}