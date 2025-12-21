using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Infra.Extensions
{
    public static class AddInfraExtensions
    {
        public static void AddInfraStartUp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ControleFinanceiroContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Chinook"));
            });
            services.AddScoped(typeof(IBaseInterface<>), typeof(BaseRepository<>));
            services.AddScoped<IPessoaInterface, PessoaRepository>();
            services.AddScoped<ICategoriaInterface, CategoriaRepository>();
        }
    }
}
