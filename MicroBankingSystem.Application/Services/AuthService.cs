using AutoMapper;
using MicroBankingSystem.Application.Contracts.Services;
using MicroBankingSystem.Application.DTOs.Auth;
using MicroBankingSystem.domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroBankingSystem.Application.Services
{
    public class AuthService(
        IConfiguration _configuration ,
        UserManager<ApplicationUser> _userManager,
        IMapper _mapper
        ) : IAuthService
    {

        // Login method
        public async Task<AuthResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                throw new ArgumentNullException(nameof(loginDTO));
            
            var user = await  _userManager.FindByEmailAsync( loginDTO.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user , loginDTO.Password))
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "Invalid email or password."
                };

            var token = GenerateJwtToken(user);

            return new AuthResponseDTO
            {
                Success = true,
                Message = "Login successful.",
                Token = token,
                ExpiresAt = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:DurationInMinutes"])),
                UserId = user.Id,
                UserName = user.UserName
            };
        }

        // Register method
        public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            
                if (registerDTO == null)
                    throw new ArgumentNullException(nameof(registerDTO));

                var user = await _userManager.FindByEmailAsync(registerDTO.Email);
                if (user != null)
                    throw new Exception("User with this email already exists.");

                user = _mapper.Map<ApplicationUser>(registerDTO);
                var result = await _userManager.CreateAsync(user, registerDTO.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e=>e.Description));
                    throw new Exception($"User creation failed: {errors}");
                }
                return new AuthResponseDTO
                {
                    Success = true,
                    Message = "User registered successfully.",
                    UserId = user.Id,
                };
        }

        public Task RequestResetPasswordAsync(RequestResetPasswordDTO requestResetPasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim> {
            
                new (ClaimTypes.NameIdentifier , user.Id),
                new (ClaimTypes.Email , user.Email!),
                new (ClaimTypes.Name , user.UserName!),
                new (JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
