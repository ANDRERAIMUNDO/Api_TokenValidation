using System.Net;
using System.Linq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Dto.Uf;
using Newtonsoft.Json;
namespace Api.Integration.Test.Uf
{
    public class QuandoRequisitarUf : BaseIntegration
    {
        [Fact]
        public async Task PossivelRealizarCrudCompleto()
        {
            await AdicionarToken();
            //GetAll
            response = await client.GetAsync($"{hostApi}Ufs");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count()==27);
            Assert.True(listaFromJson.Where(r => r.Sigla == "SP").Count() ==1);

            //GetId
            var id = listaFromJson.Where(r => r.Sigla == "SP").FirstOrDefault().Id;
            response = await client.GetAsync($"{hostApi}Ufs/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();

            var registroSelecionado = JsonConvert.DeserializeObject<UfDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal("São Paulo", registroSelecionado.Nome);
            Assert.Equal("SP", registroSelecionado.Sigla);
        }
    }
}