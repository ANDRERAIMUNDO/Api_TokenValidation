using AutoMapper;
using Api.Domain.Dto.User;
using Api.Domain.Models;
using Api.Domain.Models.UF;
using Api.Domain.Dto.Uf; 
using Api.Domain.Models.Municipio;
using Api.Domain.Dto.Municipio;
using Api.Domain.Models.Cep;
using Api.Domain.Dto.Cep;
namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile ()
        {
            #region Use
            CreateMap<UserModel, UseDto>()
            .ReverseMap();
            CreateMap<UserModel, UseDtoCreate>()
            .ReverseMap();
            CreateMap<UserModel, UseDtoUpdate>()
            .ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfModel, UfDto>()
            .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioDto>()
            .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCreate>()
            .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>()
            .ReverseMap();
            #endregion

            #region Cep
            CreateMap<CepModel, CepDto>()
            .ReverseMap();
            CreateMap<CepModel, CepDtoCreate>()
            .ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>()
            .ReverseMap();
            #endregion
        }
    }
}