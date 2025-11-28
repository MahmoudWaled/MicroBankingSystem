using MicroBankingSystem.domain.Entities;
using MicroBankingSystem.domain.Paramter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.Contracts.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync(PaginationParamter paginationParamter);
        Task<Transaction?> GetByReferenceNumberAsync(string referenceNumber );
        Task<Transaction?> GetByIdAsync(int id);
        Task AddAsync(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(Transaction  transaction);
    }
}
