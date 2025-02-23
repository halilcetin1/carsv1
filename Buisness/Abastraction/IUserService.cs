using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Dtos;
using Core.Models;

namespace Buisness.Abastraction
{
    public interface IUserService
    {
        Task<ApiResponse> Register(RegisterRequestDto model);
        Task<ApiResponse> Login(LoginRequestDto model);

    }
}
