using AutoMapper;
using MicroBankingSystem.Application.DTOs.Account;
using MicroBankingSystem.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountDTO, Account>()
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(rsc => rsc.InitialBalance));
            CreateMap<Account, AccountResponseDTO>()
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.AccountType.ToString()));
        }
    }
}
