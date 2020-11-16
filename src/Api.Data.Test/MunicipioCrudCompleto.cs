using System;
using Xunit;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using System.Linq;
namespace Api.Data.Test
{
    public class MunicipioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public MunicipioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        [Fact(DisplayName="MunicipioCrudTesteCompleto")]
        [Trait("CRUD", "MUnicipioEntity")]
        public async Task MunicipioCrudTesteCompleto()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositorio = new MunicipioImplementation(context);
                MunicipioEntity _entity = new MunicipioEntity
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new System.Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };
                var _resgistroCriado = await _repositorio.IsertAsync(_entity);

                Assert.NotNull(_resgistroCriado);
                Assert.Equal(_entity.Nome, _resgistroCriado.Nome);
                Assert.Equal(_entity.CodIBGE, _resgistroCriado.CodIBGE);
                Assert.Equal(_entity.UfId, _resgistroCriado.UfId);
                Assert.False(_resgistroCriado.Id == Guid.Empty);

                _entity.Nome = Faker.Address.City();
                _entity.Id =_resgistroCriado.Id;

                var _registroAtulizado = await _repositorio.UpdateAsync(_entity);
                
                Assert.NotNull(_registroAtulizado);
                Assert.Equal(_entity.Nome, _registroAtulizado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroAtulizado.CodIBGE);
                Assert.Equal(_entity.UfId, _registroAtulizado.UfId);
                Assert.True(_resgistroCriado.Id == _entity.Id);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtulizado.Id);
                
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtulizado.Id);

                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtulizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtulizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtulizado.UfId, _registroSelecionado.UfId);
                Assert.Null(_registroSelecionado.Uf);

                _registroSelecionado = await _repositorio.GetCompleteIBGE(_registroAtulizado.CodIBGE);

                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtulizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtulizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtulizado.UfId, _registroSelecionado.UfId);
                Assert.NotNull(_registroSelecionado.Uf);

                _registroSelecionado = await _repositorio.GetCompleteById(_registroAtulizado.Id);

                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtulizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtulizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtulizado.UfId, _registroSelecionado.UfId);
                Assert.NotNull(_registroSelecionado.Uf);

                var _todosOsRegistros = await _repositorio.SelectAsync();

                Assert.NotNull(_todosOsRegistros);
                Assert.True(_todosOsRegistros.Count() >0);

                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);

                Assert.True(_removeu);

                _todosOsRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosOsRegistros);
                Assert.True(_todosOsRegistros.Count()==0);
            }
        }
    }
}