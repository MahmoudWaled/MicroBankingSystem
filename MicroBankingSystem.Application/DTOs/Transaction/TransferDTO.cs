using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.DTOs.Transaction
{
    public class TransferDTO
    {
        public string FromAccountNumber { get; set; } = default!;
        public string ToAccountNumber { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = default!;
    }
}
