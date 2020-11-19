using System.Collections.Generic;
using System;
using Xunit;
using Api.Domain.Models.Municipio;
using Api.Domain.Entities;
using Api.Domain.Dto.Municipio;
using System.Linq;
namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {
        [Fact(DisplayName="PossivelMapearMunicipios")]
        public void PossivelMapearMunicipios()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            var listaEntity = new List<MunicipioEntity>();
            for(int i =0; i <5; i++)
              {
                var item = new MunicipioEntity
                  {
                     Id = Guid.NewGuid(),
                     Nome = Faker.Address.City(),
                     CodIBGE = Faker.RandomNumber.Next(1000000, 99999999),
                     UfId = Guid.NewGuid(),
                     CreateAt = DateTime.UtcNow,
                     UpdateAt = DateTime.UtcNow,
                     Uf = new UfEntity
                     {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                     }
              };
              listaEntity.Add(item);
            }

            var entity  =  Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.UfId, model.UfId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            var useDto = Mapper.Map<MunicipioDto>(entity);
            Assert.Equal(useDto.Id, entity.Id);
            Assert.Equal(useDto.Nome, entity.Nome);
            Assert.Equal(useDto.CodIBGE, entity.CodIBGE);
            Assert.Equal(useDto.UfId, entity.UfId);

            var useDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listaEntity.FirstOrDefault());
            Assert.Equal(useDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(useDtoCompleto.Nome, listaEntity.FirstOrDefault().Nome);
            Assert.Equal(useDtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(useDtoCompleto.UfId, listaEntity.FirstOrDefault().UfId);
            Assert.NotNull(useDtoCompleto.Uf);

            var listaDto = Mapper.Map<List<MunicipioDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i =0; i < listaDto.Count(); i++)
            {
            Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
            Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
            Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
            Assert.Equal(listaDto[i].UfId, listaEntity[i].UfId);
            }

            var useDtoCreateResult = Mapper.Map<MunicipioDtoCreateResult>(entity);
            Assert.Equal(useDtoCreateResult.Id, entity.Id);
            Assert.Equal(useDtoCreateResult.Nome, entity.Nome);
            Assert.Equal(useDtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(useDtoCreateResult.UfId, entity.UfId);
            Assert.Equal(useDtoCreateResult.CreateAt, entity.CreateAt);

            var useDtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(useDtoUpdateResult.Id, entity.Id);
            Assert.Equal(useDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(useDtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(useDtoUpdateResult.UfId, entity.UfId);
            Assert.Equal(useDtoUpdateResult.UpdateAt, entity.UpdateAt);

            var usemodel = Mapper.Map<MunicipioModel>(useDto);
            Assert.Equal(usemodel.Id, useDto.Id);
            Assert.Equal(usemodel.Nome, useDto.Nome);
            Assert.Equal(usemodel.CodIBGE, useDto.CodIBGE);
            Assert.Equal(usemodel.UfId, useDto.UfId);

            var useDtoCreate = Mapper.Map<MunicipioDtoCreate>(usemodel);
            Assert.Equal(useDtoCreate.Nome, usemodel.Nome);
            Assert.Equal(useDtoCreate.CodIBGE, usemodel.CodIBGE);
            Assert.Equal(useDtoCreate.UfId, usemodel.UfId);

            var useDtoUpdate = Mapper.Map<MunicipioDtoUpdate>(usemodel);
            Assert.Equal(useDtoUpdate.Id, usemodel.Id);
            Assert.Equal(useDtoUpdate.Nome, usemodel.Nome);
            Assert.Equal(useDtoUpdate.CodIBGE, usemodel.CodIBGE);
            Assert.Equal(useDtoUpdate.UfId, usemodel.UfId);
        }
    }
}