
namespace snack_spot.Configurations;

public static class ConfigureRoutes
{
    public static void UseAppRoutes(this WebApplication app)
    {
        app.MapControllerRoute(
            name: "categoriaFiltro",
            pattern: "Lanche/{action}/{categoria?}",
            defaults: new { Controller = "Lanche", action = "List" }
        );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        app.MapControllerRoute(
            name: "areas",
            pattern: "{area=exists}/{controller=Admin}/{action=Index}/{id?}"
        );
    }
}
