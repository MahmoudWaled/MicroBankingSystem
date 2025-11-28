using AutoMapper;
using MicroBankingSystem.Application.DTOs.Auth;
using MicroBankingSystem.domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.MappingProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterDTO, ApplicationUser>();
        }
    }
}
