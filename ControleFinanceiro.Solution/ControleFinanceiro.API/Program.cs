using ControleFinanceiro.API.Extensions;
var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var configuration = builder.Configuration;
builder.Services.ConfigureServices(builder.Configuration, builder.Environment);
var app = builder.Build();
app.Configure();
app.Run();
public partial class Program { }