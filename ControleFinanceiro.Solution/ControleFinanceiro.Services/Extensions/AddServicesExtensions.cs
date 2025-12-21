using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Infra.Repository;
using ControleFinanceiro.Services.Interface;
using ControleFinanceiro.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Services.Extensions
{
    public static class AddServicesExtensions
    {
        public static void AddServicesStartUp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseInterface<>), typeof(BaseRepository<>));
            services.AddScoped<IPessoaServices, PessoaServices>();
            services.AddScoped<ICategoriaService, CategoriaServices>();
        }
    }
}
