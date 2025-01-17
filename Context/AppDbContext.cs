using Microsoft.EntityFrameworkCore;
using snack_spot.Models;

namespace snack_spot.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Lanche> Lanche { get; set; }
    public DbSet<CarrinhoCompraItem> CarrinhoCompraItem { get; set; }
}