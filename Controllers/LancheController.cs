using Microsoft.AspNetCore.Mvc;
using snack_spot.Interfaces;
using snack_spot.ViewModels;

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
        var lancheListViewModel = new LancheListViewModel();
        lancheListViewModel.Lanches = _lancheRepository.Lanches;
        lancheListViewModel.CategoriaAtual = "Categoria";

        return View(lancheListViewModel);
    }
}