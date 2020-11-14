using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Api.Data.Mapping.Cep
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Cep");
            builder.HasKey(u=>u.Id);
            builder.HasIndex(u=>u.Cep);
            builder.HasOne(u=>u.Municipio)
            .WithMany(m=>m.Ceps);
        }
    }
}