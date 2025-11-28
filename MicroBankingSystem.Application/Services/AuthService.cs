using MicroBankingSystem.Application.Contracts.Services;
using MicroBankingSystem.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        public Task<AuthResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }

        public Task RequestResetPasswordAsync(RequestResetPasswordDTO requestResetPasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            throw new NotImplementedException();
        }
    }
}
