using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Test.ControleFinanceiro.Mock;
using System.Net;
using System.Net.Http.Json;

namespace ControleFinanceiro.Test.ControleFinanceiro.IntegrationTest
{
    public class PessoaControllerTests: IClassFixture<ControleFinanceiroConnection>
    {
        private readonly HttpClient _client;
        private readonly ControleFinanceiroConnection _factory;

        public PessoaControllerTests(ControleFinanceiroConnection factory)
        {
            _factory = factory;
            ControleFinanceiroMock.ResetDatabase(_factory).Wait();
            ControleFinanceiroMock.SeedDatabase(_factory).Wait();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllPessoas_DeveRetornar200EOk()
        {
            var response = await _client.GetAsync("/api/v1/Pessoa/BuscarTodasAsPessoas");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreatePessoa_ComDadosValidos_DeveRetornar200()
        {
            var pessoa = new PessoaDTO.PessoaDTOCreate
            {
                Nome = "Maria",
                Idade = 22
            };

            var response = await _client.PostAsJsonAsync("/api/v1/Pessoa/CadastrarNovaPessoa", pessoa);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreatePessoa_ComIdadeInvalida_DeveRetornar400()
        {
            var pessoa = new PessoaDTO.PessoaDTOCreate
            {
                Nome = "Erro",
                Idade = 0
            };

            var response = await _client.PostAsJsonAsync("/api/v1/Pessoa/CadastrarNovaPessoa", pessoa);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
