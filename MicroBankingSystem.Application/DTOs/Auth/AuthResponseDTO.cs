using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; } = default!;
        public string? Token { get; set; } = default!;
        public DateTime? ExpiresAt { get; set; }
        public string? UserId { get; set; } = default!;
        public string? UserName { get; set; } = default!;
    }
}
