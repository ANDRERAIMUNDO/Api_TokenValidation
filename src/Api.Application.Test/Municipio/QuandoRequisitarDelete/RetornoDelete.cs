using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Api.Application.Controllers;
namespace Api.Application.Test.Municipio.QuandoRequisitarDelete
{
    public class RetornoDelete : ControllerBase
    {
         private MunicipiosController _controller;

         [Fact(DisplayName="DeleteRetorno")]
         public async Task DeleteRetorno()
         {
             var serviceMock = new Mock<IMunicipioService>();
             serviceMock.Setup(m=>m.Delete(It.IsAny<Guid>()))
             .ReturnsAsync(true);

             _controller = new MunicipiosController(serviceMock.Object);

             var result = await  _controller.Delete(Guid.NewGuid());
             Assert.True(result is OkObjectResult);
         }
    }
}