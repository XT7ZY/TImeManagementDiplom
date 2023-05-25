using System.ComponentModel.DataAnnotations;



namespace TImeManagement.Data.Enums
{
    public enum RolesEnum
    {
        [Display(Name ="root")]
        Root = 1,

        [Display(Name ="admin")]
        Admin = 2,

        [Display(Name ="employer")]
        Employer = 3,

        [Display(Name = "employerDispetcher")]
        EployerDispetcher = 4,

        [Display(Name = "employerCook")]
        EployerCook = 5,

        [Display(Name = "employerWaiter")]
        EployerWaiter = 6,
    }
}
