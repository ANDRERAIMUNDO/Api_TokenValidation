using AutoMapper;
using Api.Domain.Dto.User;
using Api.Domain.Models;
namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile ()
        {
            CreateMap<UserModel, UseDto>()
            .ReverseMap();
            CreateMap<UserModel, UseDtoCreate>()
            .ReverseMap();
            CreateMap<UserModel, UseDtoUpdate>()
            .ReverseMap();
        }
    }
}