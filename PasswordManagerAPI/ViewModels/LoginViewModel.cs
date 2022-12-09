using System.ComponentModel.DataAnnotations;

namespace PasswordManagerAPI.ViewModels;

public class LoginViewModel
{
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    [Required(ErrorMessage = "O campo <Email> é obrigatório!")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo <Password> é obrigatório!")]
    [MinLength(4)]
    public string Password { get; set; }
}