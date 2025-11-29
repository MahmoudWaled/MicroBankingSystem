using MicroBankingSystem.Application.Contracts.Services;
using MicroBankingSystem.Application.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroBankingSystem.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody]LoginDTO loginDTO)
        {
            var response = await _authService.LoginAsync(loginDTO);
            return Ok(response);
        }

        [HttpPost("register")]
        public async  Task<IActionResult> Register ([FromBody]RegisterDTO registerDTO)
        {
            var response = await _authService.RegisterAsync(registerDTO);
            return Ok(response);
        }

    }
}
