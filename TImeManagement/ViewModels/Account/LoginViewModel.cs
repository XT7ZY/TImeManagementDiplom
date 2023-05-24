using System.ComponentModel.DataAnnotations;

namespace TImeManagement.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите логин")]
        [MaxLength(20, ErrorMessage = "Максимальная длина логина 20 букв")]
        [MinLength(3, ErrorMessage = "Минимальная длина логина 3 букв")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        public string Password { get; set; }
    }
}
