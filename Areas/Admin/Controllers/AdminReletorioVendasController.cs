using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using snack_spot.Areas.Admin.Services;
using snack_spot.Models;

namespace snack_spot.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminReletorioVendasController : Controller
{
    private readonly RelatorioVendasService _relatorioVendasService;

    public AdminReletorioVendasController(RelatorioVendasService relatorioVendasService)
    {
        _relatorioVendasService = relatorioVendasService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> RelatorioVendaSimples(DateTime? iniDate, DateTime? finalDate)
    {
        if (!iniDate.HasValue)
        {
            iniDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }
        else
        {
            iniDate = DateTime.SpecifyKind(iniDate.Value, DateTimeKind.Utc).ToUniversalTime();
        }

        if (!finalDate.HasValue)
        {
            finalDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTimeKind.Utc);
        }
        else
        {
            finalDate = DateTime.SpecifyKind(finalDate.Value, DateTimeKind.Utc).ToUniversalTime();
        }

        ViewData["iniDate"] = iniDate.Value.ToString("yyyy-MM-dd");
        ViewData["finalDate"] = finalDate.Value.ToString("yyyy-MM-dd");

        List<Pedido> resultado = await _relatorioVendasService.FindByDateAsync(iniDate, finalDate);

        return View(resultado);
    }
}