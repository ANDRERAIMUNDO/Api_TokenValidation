using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Municipio;
using Api.Application.Controllers;
namespace Api.Application.Test.Municipio.QuandoRequisitarCreate
{
    public class RetornoBadRequest : ControllerBase
    {
        private MunicipiosController _controller;

        [Fact(DisplayName="PossivelCreateMunicipio")]
        public async Task MunicipioCreate()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m=>m.Post(It.IsAny<MunicipioDtoCreate>()))
            .ReturnsAsync(
                new MunicipioDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    CreateAt = DateTime.UtcNow
                }
            );
            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "Nome é campo obrigatorio");

            Mock<IUrlHelper> url= new Mock<IUrlHelper>();
            url.Setup(x=> x.Link(It.IsAny<string>(), It.IsAny<object>()))
            .Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var municipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = "São Paulo",
                CodIBGE =1
            };
            
            var result = await _controller.Post(municipioDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}