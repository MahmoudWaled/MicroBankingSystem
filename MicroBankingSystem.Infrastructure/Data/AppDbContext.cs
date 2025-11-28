using MicroBankingSystem.domain.Entities;
using MicroBankingSystem.domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext( DbContextOptions<AppDbContext> options ) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique();

            builder.Entity<Account>()
                .Property(a=>a.RowVersion)
                .IsRowVersion();

            builder.Entity<Transaction>()
                .HasIndex(t=>t.ReferenceNumber)
                .IsUnique();

            builder.Entity<Transaction>()
                .HasOne(t => t.FromAccount)
                .WithMany(a => a.SentTransactions)
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Transaction>()
                .HasOne(t => t.ToAccount)
                .WithMany(a => a.ReacivedTransactions)
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);


        }

        
    }
}
