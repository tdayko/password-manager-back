using System.ComponentModel.DataAnnotations;

namespace PasswordManagerAPI.ViewModels;

public class AddCredentialViewModel
{
    [Required(ErrorMessage = "O campo <Name> é obrigatório!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O campo <Password> é obrigatório!")]
    public string Password { get; set; }
    [Required] public string Uri { get; set; }
    
}