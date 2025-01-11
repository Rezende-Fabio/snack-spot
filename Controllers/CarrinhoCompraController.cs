using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using snack_spot.Interfaces;
using snack_spot.Models;
using snack_spot.ViewModels;

namespace snack_spot.Controllers;

public class CarrinhoCompraController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
    {
        _lancheRepository = lancheRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Index()
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

    public RedirectToActionResult AdicionarItemCarrinhoCompra(int idLanche)
    {
        Lanche lancheSelec = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == idLanche);

        if (lancheSelec != null)
        {
            _carrinhoCompra.AdicionarAoCarrinho(lancheSelec);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoverItemCarrinhoCompra(int idLanche)
    {
        Lanche lancheSelec = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == idLanche);

        if (lancheSelec != null)
        {
            _carrinhoCompra.RemoverDoCarrinho(lancheSelec);
        }

        return RedirectToAction("Index");
    }
}