using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MsConfiguracion.Api.Tests
{
    public class ZonaControllerTest
    {
        IntegrationTestBuilder _builder;
        HttpClient _client = default!;

        public ZonaControllerTest()
        {
            _builder = new IntegrationTestBuilder();
            _client = _builder.CreateClient();
        }

        [Fact]
        public async Task PostZonaSuccess()
        {
            var getAllEquipos = await _client.GetAsync($"api/Equipos");


            //var postContent = new XM_SUICC.Application.Person.Commands.PersonCreateCommand
            //(
            //    "john", "doe", "john@doe.com", System.DateTime.Now.AddYears(-20)
            //);
            //var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(postContent), System.Text.Encoding.UTF8, "text/json");
            //var c = await _client.PostAsync("api/Person", content);
            //c.EnsureSuccessStatusCode();
            //Assert.Equal(HttpStatusCode.OK, c.StatusCode);
        }

    }
}
