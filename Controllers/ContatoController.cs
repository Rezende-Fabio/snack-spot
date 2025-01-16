using Microsoft.AspNetCore.Mvc;

namespace snack_spot.Controllers;

public class ContatoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}