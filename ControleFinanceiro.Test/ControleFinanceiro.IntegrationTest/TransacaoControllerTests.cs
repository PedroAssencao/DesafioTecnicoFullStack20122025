using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Enums.Base;
using ControleFinanceiro.Test.ControleFinanceiro.Mock;
using System.Net;
using System.Net.Http.Json;

namespace ControleFinanceiro.Test.ControleFinanceiro.IntegrationTest
{
    public class TransacaoControllerTests : IClassFixture<ControleFinanceiroConnection>
    {
        private readonly HttpClient _client;
        private readonly ControleFinanceiroConnection _factory;

        public TransacaoControllerTests(ControleFinanceiroConnection factory)
        {
            _factory = factory;
            ControleFinanceiroMock.ResetDatabase(_factory).Wait();
            ControleFinanceiroMock.SeedDatabase(_factory).Wait();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllTransacoes_DeveRetornar200()
        {
            var response = await _client.GetAsync("/api/v1/Transacoes/BuscarTodasAsTransacoes");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateTransacao_Valida_DeveRetornar200()
        {
            var transacao = new TransacoesDTO.transacoesDTOCreate
            {
                Descricao = "Teste",
                Valor = 100,
                Tipo = ETipoTransacaoEnum.Despesa,
                PessoaCodigo = 1,
                CategoriaCodigo = 2
            };

            var response = await _client.PostAsJsonAsync("/api/v1/Transacoes/CriarTransacao", transacao);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateTransacao_ReceitaComCategoriaDespesa_DeveRetornar400()
        {
            var transacao = new TransacoesDTO.transacoesDTOCreate
            {
                Descricao = "Erro",
                Valor = 100,
                Tipo = ETipoTransacaoEnum.Receita,
                PessoaCodigo = 1,
                CategoriaCodigo = 2
            };

            var response = await _client.PostAsJsonAsync("/api/v1/Transacoes/CriarTransacao", transacao);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
