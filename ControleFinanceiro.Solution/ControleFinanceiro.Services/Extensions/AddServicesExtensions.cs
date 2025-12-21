using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Infra.Repository;
using ControleFinanceiro.Services.Interface;
using ControleFinanceiro.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Services.Extensions
{
    // Classe de extensão para centralizar a configuração de Injeção de Dependência (DI).
    // Facilita a manutenção e mantém o Program.cs/Startup.cs limpo.
    public static class AddServicesExtensions
    {
        public static void AddServicesStartUp(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do Repositório Genérico. 
            // O uso de 'typeof' permite que qualquer entidade use o BaseRepository sem precisar de registro individual.
            services.AddScoped(typeof(IBaseInterface<>), typeof(BaseRepository<>));

            // Registro das Services especializadas.
            services.AddScoped<IPessoaServices, PessoaServices>();
            services.AddScoped<ICategoriaService, CategoriaServices>();
            services.AddScoped<ITransacoesServices, TransacaoServices>();
        }
    }
}