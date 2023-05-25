using System.ComponentModel.DataAnnotations;

namespace TImeManagement.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        public string Login { get ; set; }

        [Required(ErrorMessage = "Введите старый пароль")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "Введите новый пароль")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Пароль должен быть минимум 6 символов")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите новый пароль")]
        [Compare(otherProperty: "NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string NewPasswordConfirm { get; set; }
    }
}
