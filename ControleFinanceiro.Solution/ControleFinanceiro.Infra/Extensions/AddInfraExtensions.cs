using ControleFinanceiro.Infra.DAL;
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
        }
    }
}
