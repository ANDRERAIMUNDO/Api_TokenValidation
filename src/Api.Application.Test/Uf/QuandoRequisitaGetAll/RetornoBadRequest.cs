using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dto.Uf;
using Api.Application.Controllers;
namespace Api.Application.Test.Uf.QuandoRequisitaGetAll
{
    public class RetornoBadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName="PossivelGetAllUf")]
        public async Task PossivelGetAllUf()
        {
          var serviceMock = new Mock<IUfService>();
          serviceMock.Setup(m =>m.GetAll()).
          ReturnsAsync(
              new List<UfDto>
              {
                  new UfDto
                  {
                      Id = Guid.NewGuid(),
                      Nome = "São Paulo",
                      Sigla = "Sp",
                  },
                  new UfDto
                  {
                      Id = Guid.NewGuid(),
                      Nome = "Amazonas",
                      Sigla = "Am",
                  }
              }
          );   
          _controller = new UfsController (serviceMock.Object);
          _controller.ModelState.AddModelError("Id", "Formato invalido");

          var result = await _controller.GetAll();
          Assert.True(result is BadRequestObjectResult);
        }
    }
}