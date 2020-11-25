using System.Collections.Generic;
using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Municipio;
using Api.Application.Controllers;
namespace Api.Application.Test.Municipio.QuandoRequisitarGetAll
{
    public class RetornoOK : ControllerBase
    {
         private MunicipiosController _controller;

         [Fact(DisplayName="OkRetorno")]
         public async Task OkRetorno()
         {
             var serviceMock = new Mock<IMunicipioService>();
             serviceMock.Setup(m=>m.GetAll())
             .ReturnsAsync(
                 new List <MunicipioDto>
                 {
                     new MunicipioDto
                     {
                     Id = Guid.NewGuid(),
                     Nome = "São Paulo",
                     },
                     new MunicipioDto
                     {
                         Id = Guid.NewGuid(),
                         Nome = "Limeira,"
                     }
                 }
             );

             _controller = new MunicipiosController(serviceMock.Object);

             var result = await  _controller.GetAll();
             Assert.True(result is OkObjectResult);
         }
    }
}