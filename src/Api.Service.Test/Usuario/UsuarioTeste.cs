using Api.Domain.Dto.User;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.Usuario
{
    public class UsuarioTeste
    {
        public static string NomeUsuario {get;set;}
        public static string EmailUsuario{ get;set;}
        public static string NomeUsuarioAlterado{ get;set;}
        public static string EmailUsuarioAlterado {get;set;}
        public static Guid IdUsuario {get;set;}

        public List<UseDto>listaUserDto = new List<UseDto>();
        public UseDto useDto;
        public UseDtoCreate useDtoCreate;
        public UseDtoCreateResult useDtoCreateResult;
        public UseDtoUpdate useDtoUpdate;
        public UseDtoUpdateResult useDtoUpdateResult;
        public UsuarioTeste()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for(int i = 0; i <20; i++)  
            {
                var dto = new UseDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listaUserDto.Add(dto);
            }
            useDto = new UseDto
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario
            };
            useDtoCreate = new UseDtoCreate
            {
                Name = NomeUsuario,
                Email = EmailUsuario
            };
            useDtoCreateResult = new UseDtoCreateResult
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
                CreateAt = DateTime.UtcNow
            };
            useDtoUpdate = new UseDtoUpdate
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };
            useDtoUpdateResult = new UseDtoUpdateResult
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}