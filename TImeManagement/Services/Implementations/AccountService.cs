using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TImeManagement.Data.Enums;
using TImeManagement.Data.Helpers;
using TImeManagement.Data.Interfaces;
using TImeManagement.Data.Response;
using TImeManagement.Models;
using TImeManagement.Services.Interfaces;
using TImeManagement.ViewModels.Account;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TImeManagement.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<Employer> _employerRepository;
        private readonly ILogger <AccountService> _logger;


        public AccountService(IBaseRepository<Employer> employerRepository, ILogger<AccountService> logger)
        {
            _logger = logger;
            _employerRepository = employerRepository;
        }


        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                var employer = await _employerRepository.GetAll().FirstOrDefaultAsync(x => x.UserLogin == model.Login);
                if (employer != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким логином уже есть"
                    };
                }

                employer = new Employer()
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    SurName = model.SurName,
                    RoleId = model.RoleID,
                    UserLogin = model.Login,
                    HashPassword = HashPasswordHelper.HashPassword(model.Password),
                };

                await _employerRepository.Create(employer);
                var result = Authenticate(employer);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {   
                var employer = await _employerRepository.GetAll().FirstOrDefaultAsync(x => x.UserLogin == model.Login);
                if (employer == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }

                if (employer.HashPassword != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль"
                    };
                }

                var result = Authenticate(employer);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var user = await _employerRepository.GetAll().FirstOrDefaultAsync(x => x.UserLogin == model.Login);

                if(user.HashPassword != HashPasswordHelper.HashPassword(model.OldPassword))
                {
                    return new BaseResponse<bool>()
                    {
                        StatusCode = StatusCode.PasswordUncorect,
                        Description = "Пароли не совпадают"
                    };
                }
                if (user.HashPassword == HashPasswordHelper.HashPassword(model.NewPassword))
                {
                    return new BaseResponse<bool>()
                    {
                        StatusCode = StatusCode.PasswordUncorect,
                        Description = "Новый пароль совподает со старым"
                    };
                }

                user.HashPassword = HashPasswordHelper.HashPassword(model.NewPassword);
                await _employerRepository.Update(user);


                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK,
                    Description = "Пароль обновлен"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ChangePassword]: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        private ClaimsIdentity Authenticate(Employer employer)
        {
            var rolesDict = Enum.GetValues(typeof(RolesEnum)).Cast<RolesEnum>()
                .ToDictionary(t => (int)t, t => t.ToString());

            string claim = rolesDict[employer.RoleId];

            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, employer.UserLogin),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, employer.RoleId.ToString()),///// нужно исправить
                new Claim(claim , "1")
            };


            if (claim == "Admin")                                 ////////////Лучший костыль в мире
            {
                claims.Add(new Claim("Employer", "3"));
            }
            if (claim == "Root")
            {
                claims.Add(new Claim("Employer", "3"));
                claims.Add(new Claim("Admin", "1"));
            }


            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
