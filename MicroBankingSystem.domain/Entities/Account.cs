using MicroBankingSystem.domain.Enums;
using MicroBankingSystem.domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroBankingSystem.domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string AccountNumber { get; set; } = default!;
        [Required]
        public AccountType AccountType { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }
        [Required]
        [MaxLength(3)]
        public string Currency { get; set; } = default!;

        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = null!;
        [Timestamp]
        public byte[] RowVersion { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public ICollection<Transaction> SentTransactions { get; set; }
        public ICollection<Transaction> ReacivedTransactions { get; set; }

    }
}
