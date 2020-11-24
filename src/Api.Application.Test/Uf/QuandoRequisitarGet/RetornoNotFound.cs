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
    public class RetornoNotFound
    {
        private UfsController _controller;

        [Fact(DisplayName="RetornoNot_Found")]
        public async Task RetornoNot_Found()
        {
            var serviceMock = new Mock<IUfService>();
            serviceMock.Setup(m=>m.Get(It.IsAny<Guid>())).
            Returns(Task.FromResult((UfDto)null));

            _controller = new UfsController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);    
        }
    }
}