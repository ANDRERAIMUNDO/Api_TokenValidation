using Api.Domain.Dto.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System.Collections.Generic;
using System.Linq;
using   System.Threading.Tasks;
using Xunit;
namespace Api.Service.Test.Usuario
{
    public class QuandoExecultaGetAll : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName="PossivelExecutarGetAll")]
        public async Task PossivelExecutarGetAll()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m=>m.GetAll()).ReturnsAsync(listaUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();

            Assert.NotNull(result);
            Assert.True(result.Count()==20);

            var listResult = new List<UseDto>();

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m=>m.GetAll()).ReturnsAsync(listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count()==0);
        }
    }
}