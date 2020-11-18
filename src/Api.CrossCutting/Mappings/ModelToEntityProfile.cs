using System.Net.Mime;
using AutoMapper;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Models.UF;
using Api.Domain.Models.Municipio;
using Api.Domain.Models.Cep;
namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>()
            .ReverseMap();

            CreateMap<UfModel, UfEntity>()
            .ReverseMap();

            CreateMap<MunicipioModel, MunicipioEntity>()
            .ReverseMap();

            CreateMap<CepModel, CepEntity>()
            .ReverseMap();
        }
    }
}