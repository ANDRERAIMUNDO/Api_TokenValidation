using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Api.Domain.Dto.Uf;
namespace Api.Service.Test.Uf
{
    public class QuandoForExecultarGet : UfTestes
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName="PossivelExecultaGet")]
        public async Task PossivelExecultaGet ()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m=>m.Get(IdUf))
            .ReturnsAsync(ufDto);
            _service = _serviceMock.Object;

            var result  = await _service.Get(IdUf);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUf);
            Assert.Equal(Nome, result.Nome);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
            .Returns(Task.FromResult((UfDto)null));
            _service = _serviceMock.Object;

            var record = await _service.Get(IdUf);
            Assert.Null(record);
        }
    }
}