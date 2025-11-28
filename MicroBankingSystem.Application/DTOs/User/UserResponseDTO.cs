using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.DTOs.User
{
    public class UserResponseDTO
    {
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string FullName { get; set; } = default!;
    }
}
