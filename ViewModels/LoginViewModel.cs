using System.ComponentModel.DataAnnotations;

namespace AppAgendamentos.ViewModels;
public class LoginViewModel
{
    [Required(ErrorMessage = "Field email or username is required")]
    [Display(Name = "E-mail or User Name")]
    public string EmailOrUserName { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}