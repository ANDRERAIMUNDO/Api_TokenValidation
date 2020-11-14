using System;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Data.Mapping;
using Api.Data.Mapping.Cep;
using Api.Data.Mapping.Municipio;
using Api.Data.Mapping.Uf;
using Api.Data.Seeds;
namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
       DbSet<UserEntity> Users{get;set;}
         public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<UserEntity>(new UserMap().Configure);
           modelBuilder.Entity<UfEntity>(new UfMap().Configure);
           modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
           modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            //add user default
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "adm",
                    Email = "adm@adm.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                }
            );

            UfSeeds.Ufs(modelBuilder);
        }
    }
}