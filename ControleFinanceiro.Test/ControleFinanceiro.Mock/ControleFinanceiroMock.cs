using ControleFinanceiro.Domain.Enums.Base;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Test.ControleFinanceiro.Mock;
using Microsoft.Extensions.DependencyInjection;

public static class ControleFinanceiroMock
{
    public static async Task ResetDatabase(ControleFinanceiroConnection application)
    {
        using var scope = application.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ControleFinanceiroContext>();

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
    }

    public static async Task SeedDatabase(ControleFinanceiroConnection application)
    {
        using var scope = application.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ControleFinanceiroContext>();

        if (context.Pessoas.Any())
            return;

        var pessoa = new Pessoa
        {
            PesId = 1,
            PesNome = "Pedro Assenção",
            PesIdade = 19
        };

        await context.Pessoas.AddAsync(pessoa);

        await context.Categorias.AddRangeAsync(
            new Categoria
            {
                CatId = 1,
                CatDescricao = "Salário",
                CatFinalidade = ECategoriaEnum.Receita
            },
            new Categoria
            {
                CatId = 2,
                CatDescricao = "Mercado",
                CatFinalidade = ECategoriaEnum.Despesa
            },
            new Categoria
            {
                CatId = 3,
                CatDescricao = "Misc",
                CatFinalidade = ECategoriaEnum.Ambas
            }
        );

        await context.SaveChangesAsync();

        await context.Transacoes.AddRangeAsync(
            new Transaco
            {
                TraId = 1,
                TraDescricao = "Salário Junho",
                TraValor = 5000,
                TraTipo = ETipoTransacaoEnum.Receita,
                PesId = 1,
                CatId = 1
            },
            new Transaco
            {
                TraId = 2,
                TraDescricao = "Compra Mercado",
                TraValor = 250,
                TraTipo = ETipoTransacaoEnum.Despesa,
                PesId = 1,
                CatId = 2
            },
            new Transaco
            {
                TraId = 3,
                TraDescricao = "Venda de Item Usado",
                TraValor = 300,
                TraTipo = ETipoTransacaoEnum.Receita,
                PesId = 1,
                CatId = 3
            }
        );

        await context.SaveChangesAsync();
    }
}
