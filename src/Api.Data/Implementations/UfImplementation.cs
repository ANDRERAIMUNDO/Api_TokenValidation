using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Data.Repository;
using Api.Data.Context;
namespace Api.Data.Implementations
{
    public class UfImplementation : BaseRepository <UfEntity>, IUfRepository
    {
        private DbSet <UfEntity> _dataset;
        public UfImplementation(MyContext context) : base (context)
        {
            _dataset = context.Set<UfEntity>();
        }
    }
}