using System.ComponentModel.DataAnnotations;

namespace PasswordManagerAPI.ViewModels;

public class UserViewModel
{
    [Required(ErrorMessage = "O campo <Nome> é obrigatório!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O campo <Email> é obrigatório!")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo <Password> é obrigatório!")]
    public string Password { get; set; }
}