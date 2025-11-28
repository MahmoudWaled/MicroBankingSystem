using MicroBankingSystem.Application.Contracts.Repositories;
using MicroBankingSystem.domain.Entities;
using MicroBankingSystem.domain.Paramter;
using MicroBankingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBankingSystem.Infrastructure.Repositories
{
    public class AccountRepository(AppDbContext context) : IAccountRepository
    {

        public async Task AddAsync(Account account)
        {
           await context.Accounts.AddAsync(account);
        }

        public void Delete(Account account)
        {
             context.Accounts.Remove(account);
        }

        public async Task<IEnumerable<Account>> GetAllAsync(PaginationParamter paginationParamter)
        {
           return await context.Accounts
                .Skip((paginationParamter.PageNumper -1 )* paginationParamter.PageSize)
                .Take(paginationParamter.PageSize)
                .ToListAsync();
        }

        public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
        {
            return await context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await context.Accounts.FindAsync(id);
        }

        public  void Update(Account account)
        {
              context.Accounts.Update(account);
        }
    }
}
