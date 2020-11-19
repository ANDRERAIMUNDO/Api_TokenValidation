using System.Collections.Generic;
using System;
using Xunit;
using Api.Domain.Models.UF;
using Api.Domain.Entities;
using Api.Domain.Dto.Uf;
using System.Linq;
namespace Api.Service.Test.AutoMapper
{
    public class UfMapper :BaseTesteService
    {
        [Fact(DisplayName="PossivelMapearModelosDeUf")]
        public void PossivelMapearModelosDeUf()
        {
            var model = new UfModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1,3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            var listaEntity = new List <UfEntity>();
            for (int i = 0; 1<5; i++)
            {
                var item = new UfEntity
                {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1,3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
                };

                listaEntity.Add(item);
            }         
            
            var entity = Mapper.Map<UfEntity>(model);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Sigla, model.Sigla);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);
            var useDto  = Mapper.Map<UfDto>(entity);

            Assert.Equal(useDto.Id, entity.Id);
            Assert.Equal(useDto.Nome, entity.Nome);
            Assert.Equal(useDto.Sigla, entity.Sigla);

            var listaDto  = Mapper.Map<List<UfDto>>(listaEntity);

            Assert.True(listaDto.Count() == listaEntity.Count());

            for (int i =0; i < 5; i++)
            {
            Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
            Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
            Assert.Equal(listaDto[i].Sigla, listaEntity[i].Sigla);
            }

            var userModel  = Mapper.Map<UfDto>(model);

            Assert.Equal(userModel.Id, model.Id);
            Assert.Equal(userModel.Nome, model.Nome);
            Assert.Equal(userModel.Sigla, model.Sigla);
        }
    }
}