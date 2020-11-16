using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace Api.Data.Test
{
    public class UfGets : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public  UfGets (DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        
        [Fact(DisplayName="RealizarGetUf")]
        [Trait("Gets", "UfEnity")]
        public async Task RealizarGetUf()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UfImplementation _repositorio = new UfImplementation(context);
                UfEntity _entity = new UfEntity
            {
                Id = new Guid ("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                Sigla = "SP",
                Nome = "São Paulo"
            };         
            var _registroExisti = await _repositorio.ExistAsync(_entity.Id);

            Assert.True(_registroExisti);

            var _registroSelecionado = await _repositorio.SelectAsync(_entity.Id);
            
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(_entity.Sigla, _registroSelecionado.Sigla);
            Assert.Equal(_entity.Nome, _registroSelecionado.Nome);
            Assert.Equal(_entity.Id, _registroSelecionado.Id);

            var _todosOsRegistros = await _repositorio.SelectAsync();
            
            Assert.True(_registroExisti);
            Assert.NotNull(_todosOsRegistros);
            Assert.True(_todosOsRegistros.Count()==27);
           }
        }
    }
}