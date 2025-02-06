using System.ComponentModel.DataAnnotations;

namespace snack_spot.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "*Informe um nome de usuário")]
    [Display(Name = "Usuário")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "*Informe uma senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}