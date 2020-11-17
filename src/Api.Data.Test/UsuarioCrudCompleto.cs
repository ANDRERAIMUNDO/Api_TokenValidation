using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Faker;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public UsuarioCrudCompleto (DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        [Fact(DisplayName="PossivelRealizarCrudusuario")]
        [Trait("Crud", "UserEntity")]
        public async Task PossivelRealizarCrudusuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                var _registroCriado = await _repositorio.InsertAsync(_entity);

                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();

                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);

                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);

                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);

                var _todosOsRegistros = await _repositorio.SelectAsync();

                Assert.NotNull(_todosOsRegistros);
                Assert.True(_todosOsRegistros.Count()>0);

                var _remover = await _repositorio.DeleteAsync(_registroSelecionado.Id);

                Assert.True(_remover);

                var _usuarioPadrao = await _repositorio.FindByLogin("adm@adm.com");

                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("adm@adm.com", _usuarioPadrao.Email);
                Assert.Equal("adm", _usuarioPadrao.Name);
            }
        }
        
    }
}                                                                                                                                               