using snack_spot.Context;
using snack_spot.Interfaces;
using snack_spot.Models;

namespace snack_spot.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;
    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> Categorias => _context.Categoria;
}