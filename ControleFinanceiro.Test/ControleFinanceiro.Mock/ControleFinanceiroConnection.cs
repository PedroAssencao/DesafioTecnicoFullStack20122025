using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Infra.Repository;
using ControleFinanceiro.Services.Interface;
using ControleFinanceiro.Services.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace ControleFinanceiro.Test.ControleFinanceiro.Mock
{
    public class ControleFinanceiroConnection : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();
            builder.UseEnvironment("Test");

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions));
                services.RemoveAll(typeof(DbContextOptions<ControleFinanceiroContext>));
                services.RemoveAll(typeof(ControleFinanceiroContext));

                services.AddDbContext<ControleFinanceiroContext>(options =>
                {
                    options.UseInMemoryDatabase("DataBase", root);

                    options.ConfigureWarnings(warnings =>
                    {
                        warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning);
                    });
                });

                services.AddScoped<IPessoaInterface, PessoaRepository>();
                services.AddScoped<ICategoriaInterface, CategoriaRepository>();
                services.AddScoped<IPessoaServices, PessoaServices>();
                services.AddScoped<ICategoriaService, CategoriaServices>();
                services.AddScoped<ITransacoesServices, TransacaoServices>();
            });   
            return base.CreateHost(builder);
        }
    }
}
