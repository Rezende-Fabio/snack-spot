
using Microsoft.AspNetCore.Mvc;

namespace snack_spot.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminController : Controller
{
    public IActionResult Index(){
        return View();
    }
}