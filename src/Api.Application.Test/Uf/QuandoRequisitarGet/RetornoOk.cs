using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Uf;
using Api.Application.Controllers;
namespace Api.Application.Test.Uf.QuandoRequisitarGet
{
    public class RetornoOk
    {
        private UfsController _controller;

        [Fact(DisplayName="PossivelRetornoOk")]
        public async Task PossivelRetornoOk()
        {
          var serviceMock = new Mock<IUfService>();
          serviceMock.Setup(m =>m.Get(It.IsAny<Guid>())).
          ReturnsAsync(
              new UfDto
              {
                  Id = Guid.NewGuid(),
                  Nome = "São Paulo",
                  Sigla = "SP" 
              }
          );
          _controller = new UfsController (serviceMock.Object);

          var result = await _controller.Get(Guid.NewGuid());
          Assert.True(result is OkObjectResult);
        }
    }
}