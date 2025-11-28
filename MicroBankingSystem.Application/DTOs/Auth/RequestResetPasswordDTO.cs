using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.DTOs.Auth
{
    public class RequestResetPasswordDTO
    {
        public string Email { get; set; } = default!;
    }
}
