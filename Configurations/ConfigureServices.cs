using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using snack_spot.Context;
using snack_spot.Interfaces;
using snack_spot.Models;
using snack_spot.Repositories;
using snack_spot.Services;

namespace snack_spot.Configurations;

public static class ConfigureServices
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddMemoryCache();
        services.AddSession();

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ISeedRoleInitial, SeedUsersRoleInitial>();

        services.AddTransient<ILancheRepository, LancheRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        services.AddScoped(car => CarrinhoCompra.GetCarrinho(car));

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin",
                policy => {
                    policy.RequireRole("Admin");
                }
            );
        });

        return services;
    }
}