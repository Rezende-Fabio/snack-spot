using Microsoft.AspNetCore.Mvc;
using snack_spot.Interfaces;

namespace snack_spot.Controllers;

public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    public LancheController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    public IActionResult List()
    {
        ViewData["Titulo"] = "Todos os lanches"; 
        var lanches = _lancheRepository.Lanches;
        return View(lanches);
    }
}