using System.Collections.Generic;
using System;
using Xunit;
using Moq;
using System.Linq;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Dto.Municipio;
using System.Threading.Tasks;
namespace Api.Service.Test.Municipio
{
    public class QuandoForExecultadoGetAll : MunicipioTestes
    {
         private IMunicipioService _service;
        private Mock <IMunicipioService> _serviceMock;

        [Fact(DisplayName="PossivelRealizarGetAll")]
        public async Task PossivelRealizarGetAll ()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.GetAll())
            .ReturnsAsync(listaDto);
            _service = _serviceMock.Object;

            var result  = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count()==10);

            var _listResult  = new List<MunicipioDto>();
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m=>m.GetAll())
            .ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() ==0); 
        }

    }
}