using System.Net.Mime;
using System;
using System.Collections.Generic;
using Api.Domain.Dto.Municipio; 
using Api.Domain.Dto.Cep;
using Api.Domain.Dto.Uf;
namespace Api.Service.Test
{
    public class CepTestes
    {
        public static string CepOriginal {get;set;}
        public static string LogradouroOriginal {get;set;}
        public static string NumeroOriginal {get;set;}
        public static string CepAlterado {get;set;}
        public static string LogradouroAlterado {get;set;}
        public static string NumeroAlterado {get;set;}
        public static Guid IdMunicipio {get;set;}
        public static Guid IdCep {get;set;}

        public List <CepDto> listaDto = new List<CepDto>();
        public CepDto cepDto;
        public CepDtoCreate cepDtoCreate;
        public CepDtoCreateResult cepDtoCreateResult;
        public CepDtoUpdate cepDtoUpdate;
        public CepDtoUpdateResult cepDtoUpdateResult;
        public CepTestes()
        {
            IdMunicipio = Guid.NewGuid();
            IdCep = Guid.NewGuid();
            CepOriginal = Faker.RandomNumber.Next(10000, 999999).ToString();
            NumeroOriginal = Faker.RandomNumber.Next(1, 1000).ToString();
            LogradouroOriginal = Faker.Address.StreetName();
            CepAlterado = Faker.RandomNumber.Next(10000, 999999).ToString();
            NumeroAlterado = Faker.RandomNumber.Next(1, 1000).ToString();

            for (int i=0; i<10; i++)
            {
                var dto = new CepDto()
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(10000, 999999).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 1000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = IdMunicipio,
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 1000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto()
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3) 
                        }
                    }
                };
                listaDto.Add(dto);
            }
            cepDto  = new CepDto()
            {
                Id = IdCep,
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                Municipio = new MunicipioDtoCompleto
                {
                    Id = IdMunicipio,
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1,1000),
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3) 
                    }
                }
            };
            cepDtoCreate = new CepDtoCreate()
            {
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
            };
            cepDtoCreateResult = new CepDtoCreateResult()
            {
                Id = IdCep,   
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                CreateAt = DateTime.UtcNow
            };  
            cepDtoUpdate = new CepDtoUpdate()
            {
                Id = IdCep,   
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio,
            };
              cepDtoUpdateResult = new CepDtoUpdateResult()          {
                Id = IdCep,   
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}