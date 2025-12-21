using ControleFinanceiro.API.Mapper.PessoaEntity;
using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Extensions;
using ControleFinanceiro.Services.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Extensions
{
    public static class StartUp
    {
        //StartUp the configurations
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

            using (var scope = app.Services.CreateScope()) //Realizar as migrações automaticamente ao iniciar a aplicação
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ControleFinanceiroContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Um error ocorreu ao tentar realizar a migration");
                }
            }

            app.UseHttpsRedirection();
            app.MapControllers();
        }
    }
}
