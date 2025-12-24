using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Enums.Base;
using ControleFinanceiro.Test.ControleFinanceiro.Mock;
using System.Net;
using System.Net.Http.Json;

namespace ControleFinanceiro.Test.ControleFinanceiro.IntegrationTest
{
    public class CategoriaControllerTests : IClassFixture<ControleFinanceiroConnection>
    {
        private readonly HttpClient _client;
        private readonly ControleFinanceiroConnection _factory;

        public CategoriaControllerTests(ControleFinanceiroConnection factory)
        {
            _factory = factory;
            ControleFinanceiroMock.ResetDatabase(_factory).Wait();
            ControleFinanceiroMock.SeedDatabase(_factory).Wait();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllCategorias_DeveRetornar200()
        {
            var response = await _client.GetAsync("/api/v1/Categoria/BuscarTodasAsCategorias");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateCategoria_ComDadosValidos_DeveRetornar200()
        {
            var categoria = new CategoriaDTO.CategoriaDTOCreate
            {
                Nome = "Lazer",
                Finalidade = ECategoriaEnum.Despesa
            };

            var response = await _client.PostAsJsonAsync("/api/v1/Categoria/CriarCategoria", categoria);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateCategoria_ComDescricaoVazia_DeveRetornar400()
        {
            var categoria = new CategoriaDTO.CategoriaDTOCreate
            {
                Nome = "",
                Finalidade = ECategoriaEnum.Receita
            };

            var response = await _client.PostAsJsonAsync("/api/v1/Categoria/CriarCategoria", categoria);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
