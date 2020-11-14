using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Api.Data.Mapping.Uf
{
    public class UfMap : IEntityTypeConfiguration<UfEntity>
    {
       public void Configure (EntityTypeBuilder<UfEntity> builder)
        {
            builder.ToTable("Uf");
            builder.HasKey(u=>u.Id);
            builder.HasIndex(u=>u.Sigla)
            .IsUnique();
        }
    }
}