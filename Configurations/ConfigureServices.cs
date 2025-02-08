using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using snack_spot.Areas.Admin.Services;
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
        services.AddScoped<RelatorioVendasService>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin",
                policy =>
                {
                    policy.RequireRole("Admin");
                }
            );
        });

        services.AddPaging(options =>
        {
            options.ViewName = "Bootstrap5";
            options.PageParameterName = "pageindex";
        });

        services.Configure<ConfigurationsImages>(configuration.GetSection("ConfigurationImagePath"));

        return services;
    }
}