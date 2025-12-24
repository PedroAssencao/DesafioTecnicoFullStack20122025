using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Test.ControleFinanceiro.UnitTest
{
    public class PessoaTeste
    {
        [Fact]
        public void Validate_PessoaValida_DeveRetornarVazio()
        {
            var pessoa = new Pessoa
            {
                PesNome = "João da Silva",
                PesIdade = 25
            };

            var result = pessoa.validate();

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Validate_IdadeMenorOuIgualZero_DeveRetornarErro()
        {
            var pessoa = new Pessoa
            {
                PesNome = "João",
                PesIdade = 0
            };

            var result = pessoa.validate();

            Assert.Contains("Idade", result);
        }

        [Fact]
        public void Validate_NomeVazio_DeveRetornarErro()
        {
            var pessoa = new Pessoa
            {
                PesNome = "",
                PesIdade = 20
            };

            var result = pessoa.validate();

            Assert.Contains("nome", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_UpdateComIdInvalido_DeveRetornarErro()
        {
            var pessoa = new Pessoa
            {
                PesId = 0,
                PesNome = "Maria",
                PesIdade = 30
            };

            var result = pessoa.validate(isUpdate: true);

            Assert.Contains("id", result, StringComparison.OrdinalIgnoreCase);
        }
    }
}
