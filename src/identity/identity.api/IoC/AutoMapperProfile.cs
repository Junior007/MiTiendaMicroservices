using AutoMapper;
using identity.api.Model;
using identity.api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.IoC
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            // OUT
            CreateMap<User, UserForDetailed>();
            CreateMap<User, UserForList>();
            // IN
            CreateMap<UserForUpdate, User>();
            CreateMap<UserForUpdate, User>();


        }
    }
}
