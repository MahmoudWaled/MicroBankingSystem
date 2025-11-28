using MicroBankingSystem.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.Contracts.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> LoginAsync (LoginDTO loginDTO);
        Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDTO);
        Task RequestResetPasswordAsync(RequestResetPasswordDTO requestResetPasswordDTO);
        Task ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO); 
        Task LogoutAsync();
    }
}
