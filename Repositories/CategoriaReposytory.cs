using snack_spot.Context;
using snack_spot.Interfaces;
using snack_spot.Models;

namespace snack_spot.Repositories;

public class CategoriaReposytory : ICategoriaRepository
{
    private readonly AppDbContext _context;
    public CategoriaReposytory(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> Categorias => _context.Categoria;
}