using MicroBankingSystem.domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroBankingSystem.domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public Guid ReferenceNumber { get; set; } = Guid.NewGuid();
        [Required]
        public TransactionType TransactionType { get; set; }
        [Required]
        public TransactionStatus Status { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,4)")]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; } = default!;
        public DateTime TransactionDate {  get; set; } = DateTime.Now;
        public int? FromAccountId { get; set; }
        public Account? FromAccount { get; set; }
        public int? ToAccountId { get; set; }
        public Account? ToAccount { get; set; }
    }
}
