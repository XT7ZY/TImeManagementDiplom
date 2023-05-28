using TImeManagement.Data.Response;
using TImeManagement.Models;
using TImeManagement.Services.Interfaces;

namespace TImeManagement.Services.Implementations
{
    public class EmployerService : IEmployerService
    {
        public Task<BaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Employer>> Edit(Employer model)
        {
            throw new NotImplementedException();
        }
    }
}
