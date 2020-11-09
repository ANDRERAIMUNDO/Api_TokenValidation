using AutoMapper;
using Api.Domain.Dto.User;
using Api.Domain.Entities;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
           CreateMap<UseDto , UserEntity>()
           .ReverseMap();
           CreateMap<UseDtoCreateResult, UserEntity>()
           .ReverseMap();
           CreateMap<UseDtoUpdateResult, UserEntity>()
           .ReverseMap();
        }
    }
}