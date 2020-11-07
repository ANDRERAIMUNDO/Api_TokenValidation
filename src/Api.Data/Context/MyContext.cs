using System;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Data.Mapping;
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
            )   ;
        }
    }
}