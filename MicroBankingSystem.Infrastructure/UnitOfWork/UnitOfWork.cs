using MicroBankingSystem.Application.Contracts.Repositories;
using MicroBankingSystem.Application.Contracts.UnitOfWork;
using MicroBankingSystem.Infrastructure.Data;
using MicroBankingSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _accountRepository = new AccountRepository(_appDbContext);
            _transactionRepository = new TransactionRepository(_appDbContext);
        }

        public IAccountRepository AccountRepository => _accountRepository;

        public ITransactionRepository TransactionRepository => _transactionRepository;


        public Task<int> CompleteAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }
    }
}
