using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using snack_spot.Context;

namespace snack_spot.Models;

public class CarrinhoCompra
{
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext context)
    {
        _context = context;
    }

    [Key]
    public string CarrinhoCompraId { get; set; }

    public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    public static CarrinhoCompra GetCarrinho(IServiceProvider serviceProvider)
    {
        ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        var context = serviceProvider.GetService<AppDbContext>();

        string idCarrinho = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        session.SetString("CarrinhoId", idCarrinho);

        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = idCarrinho
        };
    }

    public void AdicionarAoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItem.SingleOrDefault(
            s => s.Lanche.LancheId == lanche.LancheId &&
                 s.CarrinhoCompraId == CarrinhoCompraId
        );

        if (carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Lanche = lanche,
                Quantidade = 1
            };

            _context.CarrinhoCompraItem.Add(carrinhoCompraItem);
        }
        else
        {
            carrinhoCompraItem.Quantidade++;
        }

        _context.SaveChanges();
    }

    public void RemoverDoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItem.SingleOrDefault(
            s => s.Lanche.LancheId == lanche.LancheId &&
                 s.CarrinhoCompraId == CarrinhoCompraId
        );

        if (carrinhoCompraItem != null)
        {
            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
            }
            else
            {
                _context.CarrinhoCompraItem.Remove(carrinhoCompraItem);
            }
        }

        _context.SaveChanges();
    }

    public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
    {
        List<CarrinhoCompraItem> listaItens = _context.CarrinhoCompraItem
        .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
        .Include(c => c.Lanche)
        .ToList();

        return CarrinhoCompraItens ?? listaItens;
    }

    public void LimparCarrinho()
    {
        CarrinhoCompraItem carrinhoItens = _context.CarrinhoCompraItem
        .First(c => c.CarrinhoCompraId == CarrinhoCompraId);

        _context.CarrinhoCompraItem.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }

    public decimal GetCarrinhoCompraTotal()
    {
        decimal total = _context.CarrinhoCompraItem
        .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
        .Select(c => c.Lanche.Preco * c.Quantidade).Sum();

        return total;
    }
}