using TImeManagement.Data.Interfaces;
using TImeManagement.Data.Repositories;
using TImeManagement.Models;
using TImeManagement.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using TImeManagement.Services.Interfaces;

namespace TImeManagement
{
    public static class Initialize
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Employer>, EmployerRepository>();
            services.AddScoped<IRolesRepository<Role>, RolesRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

        }




    }
}
