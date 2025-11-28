using MicroBankingSystem.domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroBankingSystem.Application.DTOs.Account
{
    public class CreateAccountDTO
    {
        [Required(ErrorMessage ="Account type is required.")]
        public AccountType AccountType { get; set; }
        [Required(ErrorMessage = "Initial Balance is required.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal InitialBalance { get; set; }
        [Required(ErrorMessage = "Currency is required.")]
        public string Currency { get; set; } = default!;

    }
}
