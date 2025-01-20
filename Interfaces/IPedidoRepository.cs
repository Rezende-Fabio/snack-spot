using snack_spot.Models;

namespace snack_spot.Interfaces;

public interface IPedidoRepository
{
    void CriarPedido(Pedido pedido);
}
