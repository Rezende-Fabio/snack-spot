using Microsoft.AspNetCore.Mvc;
using snack_spot.Models;
using snack_spot.ViewModels;

namespace snack_spot.Components;

public class CarrinhoCompraResumo : ViewComponent
{   
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
    {
        _carrinhoCompra = carrinhoCompra;
    }

    public IViewComponentResult Invoke()
    {
        List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();

        _carrinhoCompra.CarrinhoCompraItens = itens;

        CarrinhoCompraViewModel carrinhoCompraVM = new CarrinhoCompraViewModel
        {
            CarrinhoCompra = _carrinhoCompra,
            TotalCarrinho = _carrinhoCompra.GetCarrinhoCompraTotal()
        };

        return View(carrinhoCompraVM);
    }
}