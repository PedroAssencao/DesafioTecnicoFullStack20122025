using ControleFinanceiro.Domain.Enums.Base;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Test.ControleFinanceiro.UnitTest
{
    public class TransacaoTeste
    {
        private static Pessoa PessoaValidaMaiorIdade() =>
        new Pessoa
        {
            PesId = 1,
            PesNome = "João",
            PesIdade = 25
        };

        private static Pessoa PessoaValidaMenorIdade() =>
            new Pessoa
            {
                PesId = 2,
                PesNome = "Pedro",
                PesIdade = 16
            };

        private static Categoria CategoriaDespesa() =>
            new Categoria
            {
                CatId = 1,
                CatDescricao = "Alimentação",
                CatFinalidade = ECategoriaEnum.Despesa
            };

        private static Categoria CategoriaReceita() =>
            new Categoria
            {
                CatId = 2,
                CatDescricao = "Salário",
                CatFinalidade = ECategoriaEnum.Receita
            };

        private static Transaco TransacaoBase() =>
            new Transaco
            {
                TraDescricao = "Teste",
                TraValor = 100,
                TraTipo = ETipoTransacaoEnum.Despesa,
                PesId = 1,
                CatId = 1,
                Pes = PessoaValidaMaiorIdade(),
                Cat = CategoriaDespesa()
            };

        [Fact]
        public void Validate_TransacaoValida_DeveRetornarVazio()
        {
            var transacao = TransacaoBase();

            var result = transacao.validate();

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Validate_DescricaoVazia_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.TraDescricao = "";

            var result = transacao.validate();

            Assert.Contains("descrição", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_DescricaoMaiorQue200Caracteres_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.TraDescricao = new string('A', 201);

            var result = transacao.validate();

            Assert.Contains("200", result);
        }

        [Fact]
        public void Validate_ValorMenorOuIgualZero_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.TraValor = 0;

            var result = transacao.validate();

            Assert.Contains("valor", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_PessoaNaoInformada_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.PesId = 0;

            var result = transacao.validate();

            Assert.Contains("pessoa", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_CategoriaNaoInformada_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.CatId = 0;

            var result = transacao.validate();

            Assert.Contains("categoria", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_ReceitaComCategoriaDespesa_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.TraTipo = ETipoTransacaoEnum.Receita;
            transacao.Cat = CategoriaDespesa();

            var result = transacao.validate();

            Assert.Contains("não poderá utilizar uma categoria", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_DespesaComCategoriaReceita_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.TraTipo = ETipoTransacaoEnum.Despesa;
            transacao.Cat = CategoriaReceita();

            var result = transacao.validate();

            Assert.Contains("não poderá utilizar uma categoria", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_MenorDeIdadeComReceita_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.Pes = PessoaValidaMenorIdade();
            transacao.TraTipo = ETipoTransacaoEnum.Receita;

            var result = transacao.validate();

            Assert.Contains("menores de idades", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_TipoTransacaoInvalido_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.TraTipo = (ETipoTransacaoEnum)999;

            var result = transacao.validate();

            Assert.Contains("tipo de transação", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_UpdateComIdInvalido_DeveRetornarErro()
        {
            var transacao = TransacaoBase();
            transacao.TraId = 0;

            var result = transacao.validate(isUpdate: true);

            Assert.Contains("id", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Validate_UpdateComIdValido_DeveRetornarVazio()
        {
            var transacao = TransacaoBase();
            transacao.TraId = 10;

            var result = transacao.validate(isUpdate: true);

            Assert.Equal(string.Empty, result);
        }
    }
}
