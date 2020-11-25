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
    public class RetornoNotFound : ControllerBase
    {
         private MunicipiosController _controller;

         [Fact(DisplayName="NotFoundRetorno")]
         public async Task NotFoundRetorno()
         {
             var serviceMock = new Mock<IMunicipioService>();
             serviceMock.Setup(m =>m.GetCompleteByIBGE(It.IsAny<int>()))
             .Returns(Task.FromResult((MunicipioDtoCompleto)null));

             _controller = new MunicipiosController(serviceMock.Object);

             var result = await  _controller.GetCompleteByIBGE(1);
             Assert.True(result is NotFoundResult);
         }
    }
}