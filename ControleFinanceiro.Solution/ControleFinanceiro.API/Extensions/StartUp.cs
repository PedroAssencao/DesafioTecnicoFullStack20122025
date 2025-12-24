using ControleFinanceiro.API.Mapper;
using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Extensions;
using ControleFinanceiro.Services.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Extensions
{
    public static class StartUp
    {
        //StartUp as configurações
        public static void StartConfiguration(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddInfraStartUp(configuration, environment);
            services.AddServicesStartUp(configuration);
            services.ConfigureMapper();
            services.ConfigureCors();
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.StartConfiguration(configuration, environment);
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PessoaProfile>();
                cfg.AddProfile<TransacoesProfile>();
                cfg.AddProfile<CategoriaProfile>();
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("frontEndWebInterface", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .AllowAnyMethod();
                    //builder.AllowAnyOrigin()
                    //       .AllowAnyHeader()
                    //       .AllowAnyMethod();
                    //builder.WithOrigins("http://localhost:3000") //Futuramente coloca a URL do front-end hospedado
                    //       .AllowAnyHeader()
                    //       .AllowAnyMethod();
                });
            });
        }

        public static void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
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


            app.UseCors("frontEndWebInterface");
            app.UseHttpsRedirection();
            app.MapControllers();
        }
    }
}
