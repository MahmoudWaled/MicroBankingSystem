using MicroBankingSystem.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        ITransactionRepository TransactionRepository { get; }

        Task<int> CompleteAsync();
    }
}
