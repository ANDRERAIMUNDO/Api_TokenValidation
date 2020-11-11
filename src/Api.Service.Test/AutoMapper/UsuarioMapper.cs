using Api.Domain.Dto.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {
        [Fact(DisplayName="PossivelMapearModelos")]
        public void PossivelMapearModelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<UserEntity>();
            for(int i = 0 ; i<5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };

                listEntity.Add(item);
            }

            var entity = Mapper.Map<UserEntity>(model);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            var useDto = Mapper.Map<UseDto>(entity);

            Assert.Equal(useDto.Id, entity.Id);
            Assert.Equal(useDto.Name, entity.Name);
            Assert.Equal(useDto.Email, entity.Email);
            Assert.Equal(useDto.CreateAt, entity.CreateAt);

            var listDto = Mapper.Map<List<UseDto>>(listEntity);

            Assert.True(listDto.Count()==listEntity.Count());
            for(int i = 0; i>listDto.Count();i++)
            {
                Assert.Equal(listDto[i].Id, listEntity[i].Id);
                Assert.Equal(listDto[i].Name, listEntity[i].Name);
                Assert.Equal(listDto[i].Email, listEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
            }

            var useDtoCreateResult = Mapper.Map<UseDtoCreateResult>(entity);

            Assert.Equal(useDtoCreateResult.Id, entity.Id);
            Assert.Equal(useDtoCreateResult.Name, entity.Name);
            Assert.Equal(useDtoCreateResult.Email, entity.Email);
            Assert.Equal(useDtoCreateResult.CreateAt, entity.CreateAt); 

            var useDtoUpdateResult = Mapper.Map<UseDtoUpdateResult>(entity);

            Assert.Equal(useDtoUpdateResult.Id, entity.Id);
            Assert.Equal(useDtoUpdateResult.Name, entity.Name);
            Assert.Equal(useDtoUpdateResult.Email, entity.Email);
            Assert.Equal(useDtoUpdateResult.UpdateAt, entity.UpdateAt);

            var useModel = Mapper.Map<UserModel>(useDto);

            Assert.Equal(useModel.Id, useDto.Id);
            Assert.Equal(useModel.Name, useDto.Name);
            Assert.Equal(useModel.Email, useDto.Email);
            Assert.Equal(useModel.CreateAt, useDto.CreateAt);

            var useDtoCreate = Mapper.Map<UseDtoCreate>(useModel);

            Assert.Equal(useDtoCreate.Name, useModel.Name);
            Assert.Equal(useDtoCreate.Email, useModel.Email);

            var useDtoUpdate = Mapper.Map<UseDtoUpdate>(useModel);

            Assert.Equal(useDtoUpdate.Id, useModel.Id);
            Assert.Equal(useDtoUpdate.Name, useModel.Name);
            Assert.Equal(useDtoUpdate.Email, useModel.Email);
        }
    }
}