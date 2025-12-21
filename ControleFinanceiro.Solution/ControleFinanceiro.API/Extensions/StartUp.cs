using ControleFinanceiro.API.Mapper.PessoaEntity;
using ControleFinanceiro.Infra.Extensions;
using ControleFinanceiro.Services.Extensions;

namespace ControleFinanceiro.API.Extensions
{
    public static class StartUp
    {
        public static void StartConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddInfraStartUp(configuration);
            services.AddServicesStartUp(configuration);
            services.ConfigureMapper();
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.StartConfiguration(configuration);
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddScoped<IPessoaMapper, PessoaMapper>();
        }

        public static void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            app.UseHttpsRedirection();
            app.MapControllers();
        }
    }
}
