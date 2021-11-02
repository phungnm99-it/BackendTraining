using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ModelDTO;
using WebAPI.Models;

namespace WebAPI.AutoMapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(des => des.RoleName, opt => opt.MapFrom(value => value.Role.RoleName))
                .ReverseMap();
            
        }
    }
}
