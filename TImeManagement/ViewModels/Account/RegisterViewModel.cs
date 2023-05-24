using System.ComponentModel.DataAnnotations;

namespace TImeManagement.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(20, ErrorMessage = "Максимальная длина иммени 20 букв")]
        [MinLength(3, ErrorMessage = "Минимальная длина иммени 3 букв")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [MaxLength(20, ErrorMessage = "Максимальная длина фамилии 20 букв")]
        [MinLength(3, ErrorMessage = "Минимальная длина фамилиии 3 букв")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите отчество")]
        [MaxLength(20, ErrorMessage = "Максимальная длина отчества 20 букв")]
        [MinLength(3, ErrorMessage = "Минимальная длина отчества 3 букв")]
        public string SurName { get; set; }

        public int RoleID { get; set; }

        [Required(ErrorMessage = "Укажите логин")]
        [MaxLength(20, ErrorMessage = "Максимальная длина логина 20 букв")]
        [MinLength(3, ErrorMessage = "Минимальная длина логина 3 букв")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен иметь длину минимум 6 символов")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare(otherProperty: "Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
