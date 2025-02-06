using System.ComponentModel.DataAnnotations;

namespace snack_spot.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "*Informe um nome de usuário")]
    [Display(Name = "Usuário")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "*Informe uma senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }

    [Required(ErrorMessage = "*Informe uma senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirme a Senha")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "*Informe um E-mail")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-mail")]
    [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "O email não possui um formato correto")]
    public string Email { get; set; }

    [Required(ErrorMessage = "*Informe uma telefone")]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Telefone")]
    public string Phone { get; set; }

    public string ReturnUrl { get; set; }
}