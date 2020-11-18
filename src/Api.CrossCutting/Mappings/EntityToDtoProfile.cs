using AutoMapper;
using Api.Domain.Dto.User;
using Api.Domain.Entities;
using Api.Domain.Dto.Uf;
using Api.Domain.Dto.Municipio;
using Api.Domain.Dto.Cep;
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
           CreateMap<UfDto, UfEntity>()
           .ReverseMap();
           CreateMap<MunicipioDto, MunicipioEntity>()
           .ReverseMap();
           CreateMap<MunicipioDtoCompleto, MunicipioEntity>()
           .ReverseMap();
           CreateMap<MunicipioDtoCreateResult, MunicipioEntity>()
           .ReverseMap();
           CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>()
           .ReverseMap();
           CreateMap<CepDto, CepEntity>()
           .ReverseMap();
           CreateMap<CepDtoCreateResult, CepEntity>()
           .ReverseMap();
           CreateMap<CepDtoUpdateResult, CepEntity>()
           .ReverseMap();
        }
    }
}