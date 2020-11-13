using System.Reflection;
using System.Text;
using System.Net.Http;
using System.Linq;
using Api.Domain.Dto.User;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace Api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario : BaseIntegration
    {
        private string _name {get;set;}
        private string _email {get;set;}

        [Fact(DisplayName="RealizarCrudUsuario")]
        public async Task RealizarCrudUsuario()
        {
            await AdicionarToken();
            _name = Faker.Name.FullName();
            _email = Faker.Internet.Email();

            var useDto = new UseDtoCreate()
            {
                Name = _name,
                Email = _email
            };
    
            var response  = await PostJsonAsync(useDto, $"{hostApi}Users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UseDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_email, registroPost.Email);
            Assert.Equal(_name, registroPost.Name);
            Assert.True(registroPost.Id != default(Guid));

            response = await client.GetAsync($"{hostApi}Users");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<UseDto>>(jsonResult);

            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r =>r.Id == registroPost.Id).Count()==1);

            var useDtoUpdate = new UseDtoUpdate
            {
                Id = registroPost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(useDtoUpdate), Encoding.UTF8, "application/json");

            response = await client.PutAsync($"{hostApi}Users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();

            var registroAtualizado = JsonConvert.DeserializeObject<UseDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Name, registroAtualizado.Name);
            Assert.NotEqual(registroPost.Email, registroAtualizado.Email);

            response = await client.GetAsync($"{hostApi}Users/{registroAtualizado.Id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();

            var registroSelecionado  = JsonConvert.DeserializeObject<UseDto>(jsonResult);

            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Name, registroAtualizado.Name);
            Assert.Equal(registroSelecionado.Email, registroAtualizado.Email);

            response = await client.DeleteAsync($"{hostApi}Users/{registroSelecionado.Id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await client.GetAsync($"{hostApi}Users/{registroSelecionado .Id}");
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);


        }
    }
}