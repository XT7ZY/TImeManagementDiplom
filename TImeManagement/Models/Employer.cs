using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace TImeManagement.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string UserLogin { get; set; }
        public string HashPassword { get; set; }
        public ICollection<Day> Days { get; set; }

    }
}
