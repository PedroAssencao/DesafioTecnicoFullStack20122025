using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Infra.Extensions
{
    // Classe de extensão para configurar as dependências da camada de Infraestrutura.
    public static class AddInfraExtensions
    {
        public static void AddInfraStartUp(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do contexto do banco de dados utilizando SQL Server.
            services.AddDbContext<ControleFinanceiroContext>(options =>
            {
                // Busca a string de conexão "Chinook" definida no appsettings.json.
                options.UseSqlServer(configuration.GetConnectionString("Chinook"));
            });

            // Registro do repositório genérico para operações base de CRUD.
            services.AddScoped(typeof(IBaseInterface<>), typeof(BaseRepository<>));

            // Registro dos repositórios especializados para Pessoa e Categoria.
            services.AddScoped<IPessoaInterface, PessoaRepository>();
            services.AddScoped<ICategoriaInterface, CategoriaRepository>();
        }
    }
}