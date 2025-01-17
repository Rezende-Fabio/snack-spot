using Microsoft.AspNetCore.Mvc;
using snack_spot.Interfaces;
using snack_spot.Models;
using snack_spot.Utils;
using snack_spot.ViewModels;

namespace snack_spot.Controllers;

public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    public LancheController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    public IActionResult List(string categoria)
    {
        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;

        if (string.IsNullOrEmpty(categoria))
        {
            lanches = _lancheRepository.Lanches.OrderBy(l => l.CategoriaId);
            categoriaAtual = "Todos os lanches";
        }
        else
        {
            lanches = _lancheRepository.Lanches
                .Where(l => l.Categoria.Nome.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Nome);
            categoriaAtual = StringUtils.Capitalize(categoria);
        }

        LancheListViewModel lancheListViewModel = new LancheListViewModel
        {
            Lanches = lanches,
            CategoriaAtual = categoriaAtual,
        };

        return View(lancheListViewModel);
    }
}