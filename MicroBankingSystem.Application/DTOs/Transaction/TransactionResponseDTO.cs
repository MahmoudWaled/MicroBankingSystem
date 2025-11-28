using MicroBankingSystem.domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.DTOs.Transaction
{
    public class TransactionResponseDTO
    {
        public string TransactionsType { get; set; } = default!;
        public string ReferenceNumber { get; set; } = default!;
        public string FromAccountNumber { get; set; } = default!;
        public string ToAccountNumber { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = default!;
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; } = default!;


    }
}
