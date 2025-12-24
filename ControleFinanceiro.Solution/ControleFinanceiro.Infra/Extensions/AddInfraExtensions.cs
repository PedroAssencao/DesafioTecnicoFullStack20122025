using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ControleFinanceiro.Infra.Extensions
{
    // Classe de extensão para configurar as dependências da camada de Infraestrutura.
    public static class AddInfraExtensions
    {
        public static void AddInfraStartUp(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            // Configuração do contexto do banco de dados utilizando SQL Server.
            services.AddDbContext<ControleFinanceiroContext>(options =>
            {
                // Busca a string de conexão "Chinook" definida no appsettings.json, apenas se não for ambiente de teste
                if (!environment.IsEnvironment("Test"))
                {
                    options.UseSqlServer(
                       configuration.GetConnectionString("Chinook")
                   );
                }
            });

            // Registro do repositório genérico para operações base de CRUD.
            services.AddScoped(typeof(IBaseInterface<>), typeof(BaseRepository<>));

            // Registro dos repositórios especializados para Pessoa e Categoria.
            services.AddScoped<IPessoaInterface, PessoaRepository>();
            services.AddScoped<ICategoriaInterface, CategoriaRepository>();
        }
    }
}