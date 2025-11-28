using MicroBankingSystem.domain.Entities;
using MicroBankingSystem.domain.Paramter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.Contracts.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync(PaginationParamter paginationParamter);  
        Task<Account?> GetByAccountNumberAsync(string accountNumber);
        Task<Account?> GetByIdAsync(int id);
        Task AddAsync(Account account);
        void Update(Account account);
        void Delete(Account account);
       
    }
}
