using MicroBankingSystem.Application.Contracts.Repositories;
using MicroBankingSystem.domain.Entities;
using MicroBankingSystem.domain.Paramter;
using MicroBankingSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MicroBankingSystem.Infrastructure.Repositories
{
    public class TransactionRepository(AppDbContext context) : ITransactionRepository
    {

        public async Task AddAsync(Transaction transaction)
        {
           await context.Transactions.AddAsync(transaction);    
        }

        public void Delete(Transaction transaction)
        {
            context.Transactions.Remove(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(PaginationParamter paginationParamter)
        {
           return await context.Transactions
                .Skip((paginationParamter.PageNumper - 1)* paginationParamter.PageSize)
                .Take(paginationParamter.PageSize)
                .ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await context.Transactions.FindAsync(id);
        }

        public async Task<Transaction?> GetByReferenceNumberAsync(string referenceNumber)
        {
            return await context.Transactions.FirstOrDefaultAsync(t => t.ReferenceNumber.ToString() == referenceNumber);
        }

        public void Update(Transaction transaction)
        {
            context.Transactions.Update(transaction);
        }
    }
}
