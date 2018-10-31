using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KS.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //maps for user registration
            CreateMap<NewUserCreateRequest, NewUserCreateDTO>();
            CreateMap<NewUserCreateDTO, UserRegisterRAO>();
            CreateMap<UserRegisterRAO, UserEntity>();

            //maps for login
            CreateMap<ExistingUserQueryRequest, QueryForExistingUserDTO>();
            CreateMap<QueryForExistingUserDTO, QueryForExistingUserRAO>();
            CreateMap<QueryForExistingUserRAO, UserEntity>();
            CreateMap<UserEntity, ReceivedUserRAO>();
            CreateMap<QueryForExistingUserRAO, ReceivedUserDTO>();
        }
    }
}
