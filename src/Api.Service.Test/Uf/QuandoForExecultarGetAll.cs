using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Xunit;
using Moq;
using System.Linq;
using Api.Domain.Interfaces.Services.Uf;
using Api.Domain.Dto.Uf;
namespace Api.Service.Test.Uf
{
    public class QuandoForExecultarGetAll : UfTestes
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName="PossivelExecultaGetAll")]
        public async Task PossivelExecultaGetAll ()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m=>m.GetAll())
            .ReturnsAsync(listaUfDto);
            _service = _serviceMock.Object;

            var result  = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count()== 10);

            var _litResult = new List<UfDto>();

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_litResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count()==0);
        }
    }
}