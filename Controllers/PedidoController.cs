using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using snack_spot.Interfaces;
using snack_spot.Models;

namespace snack_spot.Controllers;

public class PedidoController : Controller
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
    {
        _pedidoRepository = pedidoRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    [Authorize]
    public IActionResult Checkout()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public IActionResult Checkout(Pedido pedido)
    {
        int totalItensPedido = 0;
        decimal valorTotalPedio = 0.0m;

        List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItens = itens;

        if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
        {
            ModelState.AddModelError("", "Seu carrinho está vazio");
        }

        foreach (var item in itens)
        {
            totalItensPedido += item.Quantidade;
            valorTotalPedio += item.Quantidade * item.Lanche.Preco;
        }

        pedido.TotalItensPedido = totalItensPedido;
        pedido.PedidoTotal = valorTotalPedio;

        if (ModelState.IsValid)
        {
            _pedidoRepository.CriarPedido(pedido);

            ViewBag.CheckoutCompletoMensagem = "Obrigado por nos escolher :)";
            ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

            _carrinhoCompra.LimparCarrinho();

            return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
        }
        
        return View(pedido);
    }
}