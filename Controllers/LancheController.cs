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
            if (string.Equals("Natural", categoria, StringComparison.OrdinalIgnoreCase))
            {
                lanches = _lancheRepository.Lanches
                .Where(l => l.Categoria.Nome.Equals("Natural", StringComparison.OrdinalIgnoreCase))
                .OrderBy(l => l.Nome);
            }
            else if (string.Equals("Caseiro", categoria, StringComparison.OrdinalIgnoreCase))
            {
                lanches = _lancheRepository.Lanches
                .Where(l => l.Categoria.Nome.Equals("Caseiro", StringComparison.OrdinalIgnoreCase))
                .OrderBy(l => l.Nome);
            }
            else
            {
                lanches = _lancheRepository.Lanches
                .Where(l => l.Categoria.Nome.Equals("Gourmet", StringComparison.OrdinalIgnoreCase))
                .OrderBy(l => l.Nome);
            }

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