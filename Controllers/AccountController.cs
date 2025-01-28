

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using snack_spot.ViewModels;

namespace snack_spot.Controllers;


public class AccountController : Controller
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
            return View(loginViewModel);

        var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }

                return Redirect(loginViewModel.ReturnUrl);
            }
        }

        ModelState.AddModelError("", "Usuário/Senha inválido!!");
        return View(loginViewModel);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (!string.Equals(registerViewModel.Password, registerViewModel.ConfirmPassword))
        {
            this.ModelState.AddModelError("", "As senhas devem ser iguais!");
            return View(registerViewModel);
        }

        if (ModelState.IsValid)
        {
            var user = new IdentityUser()
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                PhoneNumber = registerViewModel.Phone
            };
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                this.ModelState.AddModelError("Registro", "Erro ao realizar o registro");
            }
        }

        return View(registerViewModel);
    }
}