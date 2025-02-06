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

    public IActionResult Details(int idLanche)
    {
        Lanche lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == idLanche);

        return View(lanche);
    }

    public ViewResult Search(string searchProduto)
    {
        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;

        if (string.IsNullOrEmpty(searchProduto))
        {
            lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            categoriaAtual = "Lanches";
        }
        else
        {
            lanches = _lancheRepository.Lanches
                .Where(l => l.Nome.ToLower().Contains(searchProduto.ToLower()));

            if (lanches.Any())
            {
                categoriaAtual = "Lanches";
            }
            else
            {
                categoriaAtual = "Nenhum lanche foi encontrado";
            }
        }

        return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
        {
            Lanches = lanches,
            CategoriaAtual = categoriaAtual,
        });
    }
}