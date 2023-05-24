using System.ComponentModel.DataAnnotations;



namespace TImeManagement.Data.Enums
{
    public enum RolesEnum
    {
        [Display(Name ="root")]
        Root = 1,

        [Display(Name ="employer")]
        Employer = 2,

        [Display(Name ="admin")]
        Admin = 3
    }
}
