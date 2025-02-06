using Microsoft.EntityFrameworkCore;
using snack_spot.Context;
using snack_spot.Models;

namespace snack_spot.Areas.Admin.Services;

public class RelatorioVendasService
{
    private readonly AppDbContext _context;

    public RelatorioVendasService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> FindByDateAsync(DateTime? iniDate, DateTime? finalDate)
    {
        var resultados = from obj in _context.Pedidos select obj;

        if (iniDate.HasValue)
        {
            resultados = resultados.Where(x => x.PedidoEnviado.Date >= iniDate.Value.Date);
        }
        if (finalDate.HasValue)
        {
            resultados = resultados.Where(x => x.PedidoEnviado.Date <= finalDate.Value);
        }

        return await resultados
                .Include(p => p.PedidoItens)
                .ThenInclude(l => l.Lanche)
                .OrderByDescending(p => p.PedidoEnviado)
                .ToListAsync(); 
    }
}