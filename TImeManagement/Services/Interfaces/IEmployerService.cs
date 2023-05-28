using TImeManagement.Data.Response;
using TImeManagement.Models;

namespace TImeManagement.Services.Interfaces
{
    public interface IEmployerService
    {
        Task<BaseResponse<Employer>> Edit(Employer model);
        Task<BaseResponse<bool>> Delete(int id);
    }
}
