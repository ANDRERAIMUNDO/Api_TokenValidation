using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Cep;
using Api.Application.Controllers;
namespace Api.Application.Test.Cep.QuandoRequisitarGet
{
    public class RetornoNotFound : ControllerBase
    {
        CepsController _controller;
        [Fact(DisplayName="NotFoundRetorno")]
        public async Task NotFoundRetorno()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m =>m.Get(It.IsAny<Guid>()))
            .Returns(Task.FromResult((CepDto)null));

            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}