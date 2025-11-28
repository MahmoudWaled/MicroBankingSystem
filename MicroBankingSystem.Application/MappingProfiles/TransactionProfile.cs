using AutoMapper;
using MicroBankingSystem.Application.DTOs.Transaction;
using MicroBankingSystem.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.MappingProfiles
{
    public class TransactionProfile :Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction,TransactionResponseDTO>()
                .ForMember(dest=>dest.ToAccountNumber,opt=>opt.MapFrom(src=>src.ToAccount.AccountNumber))
                .ForMember(dest=>dest.FromAccountNumber,opt=>opt.MapFrom(src=>src.FromAccount.AccountNumber))
                .ForMember(dest=>dest.TransactionsType,opt=>opt.MapFrom(src=>src.TransactionType.ToString()))
                .ForMember(dest=>dest.Status,opt=>opt.MapFrom(src=>src.Status.ToString()))
                .ForMember(dest=>dest.ReferenceNumber,opt=>opt.MapFrom(src=>src.ReferenceNumber.ToString()));

        }
    }
}
