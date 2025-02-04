using snack_spot.Configurations;
using snack_spot.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços
builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

// Configuração dos middlewares
app.UseAppMiddleware();

// Configuração das rotas
app.UseAppRoutes();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seedRoles = services.GetRequiredService<ISeedRoleInitial>();
    seedRoles.SeedRoles();
    seedRoles.SeedUsers();
}


app.Run();