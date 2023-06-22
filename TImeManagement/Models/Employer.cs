using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TImeManagement.Models
{
    public class Employer
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(20, ErrorMessage = "Максимальная длина иммени 20 символов")]
        [MinLength(3, ErrorMessage = "Минимальная длина иммени 3 символа")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите фамилию")]
        [MaxLength(20, ErrorMessage = "Максимальная длина фамилии 20 символов")]
        [MinLength(3, ErrorMessage = "Минимальная длина фамилиии 3 символа")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Укажите отчество")]
        [MaxLength(20, ErrorMessage = "Максимальная длина отчества 20 символов")]
        [MinLength(3, ErrorMessage = "Минимальная длина отчества 3 символа")]
        public string SurName { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
        [Required(ErrorMessage = "Укажите логин")]
        [MaxLength(20, ErrorMessage = "Максимальная длина логина 20 символов")]
        [MinLength(3, ErrorMessage = "Минимальная длина логина 3 символа")]
        public string UserLogin { get; set; }
        public string HashPassword { get; set; }
        public ICollection<Day>? Days { get; set; }

    }
}
