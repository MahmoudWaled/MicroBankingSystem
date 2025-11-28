using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.DTOs.Account
{
    public class AccountResponseDTO
    {
        public string AccountNumber { get; set; } = default!;
        public string AccountType { get; set; } = default!;
        public decimal Balance { get; set; }
        public string Currency { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
