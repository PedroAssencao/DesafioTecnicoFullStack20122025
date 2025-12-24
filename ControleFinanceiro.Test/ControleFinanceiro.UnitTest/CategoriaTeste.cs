using ControleFinanceiro.Domain.Enums.Base;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Test.ControleFinanceiro.UnitTest
{
    public class CategoriaTeste
    {
        [Fact]
        public void Validate_CategoriaValida_DeveRetornarVazio()
        {
            var categoria = new Categoria
            {
                CatDescricao = "Alimentação",
                CatFinalidade = ECategoriaEnum.Despesa
            };

            var result = categoria.validate();

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Validate_DescricaoVazia_DeveRetornarErro()
        {
            var categoria = new Categoria
            {
                CatDescricao = "",
                CatFinalidade = ECategoriaEnum.Despesa
            };

            var result = categoria.validate();

            Assert.Contains("descrição", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_DescricaoMaiorQue100Caracteres_DeveRetornarErro()
        {
            var categoria = new Categoria
            {
                CatDescricao = new string('A', 101),
                CatFinalidade = ECategoriaEnum.Despesa
            };

            var result = categoria.validate();

            Assert.Contains("100", result);
        }

        [Fact]
        public void Validate_FinalidadeInvalida_DeveRetornarErro()
        {
            var categoria = new Categoria
            {
                CatDescricao = "Categoria inválida",
                CatFinalidade = (ECategoriaEnum)999
            };

            var result = categoria.validate();

            Assert.Contains("finalidade", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_UpdateComIdInvalido_DeveRetornarErro()
        {
            var categoria = new Categoria
            {
                CatId = 0,
                CatDescricao = "Transporte",
                CatFinalidade = ECategoriaEnum.Despesa
            };

            var result = categoria.validate(isUpdate: true);

            Assert.Contains("id", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_UpdateComIdValido_DeveRetornarVazio()
        {
            var categoria = new Categoria
            {
                CatId = 10,
                CatDescricao = "Salário",
                CatFinalidade = ECategoriaEnum.Receita
            };

            var result = categoria.validate(isUpdate: true);

            Assert.Equal(string.Empty, result);
        }
    }
}
