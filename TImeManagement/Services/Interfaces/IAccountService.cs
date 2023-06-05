using System.Security.Claims;
using TImeManagement.Data.Response;
using TImeManagement.Models;
using TImeManagement.ViewModels.Account;

namespace TImeManagement.Services.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
        Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
        IEnumerable<Role> GetRoles();
    }
}
