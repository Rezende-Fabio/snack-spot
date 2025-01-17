
using Microsoft.AspNetCore.Mvc;
using snack_spot.Interfaces;
using snack_spot.Models;

namespace snack_spot.Components;

public class CategoriaMenu : ViewComponent
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaMenu(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public IViewComponentResult Invoke()
    {
        IEnumerable<Categoria> categorias = _categoriaRepository.Categorias.OrderBy(c => c.Nome);

        return View(categorias);
    }
}