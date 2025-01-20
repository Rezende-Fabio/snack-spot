using snack_spot.Context;
using snack_spot.Interfaces;
using snack_spot.Models;

namespace snack_spot.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoRepository(CarrinhoCompra carrinhoCompra, AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _carrinhoCompra = carrinhoCompra;
    }

    public void CriarPedido(Pedido pedido)
    {
        pedido.PedidoEnviado = DateTime.Now;

        _appDbContext.Pedidos.Add(pedido);
        _appDbContext.SaveChanges();

        var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

        foreach (var item in carrinhoCompraItens)
        {
            PedidoDetalhe detalhePedido = new PedidoDetalhe()
            {
                Quantidade = item.Quantidade,
                LancheId = item.Lanche.LancheId,
                PedidoId = pedido.PedidoId,
                Preco = item.Lanche.Preco,
            };

            _appDbContext.PedidoDetalhes.Add(detalhePedido);
        }

        _appDbContext.SaveChanges();
    }
}