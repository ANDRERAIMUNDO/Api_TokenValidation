using System;
using Api.Domain.Repository;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using System.Threading.Tasks;
namespace Api.Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;
        public MunicipioImplementation (MyContext context) : base (context)
        {
            _dataset = context.Set<MunicipioEntity>();
        }
        public async Task <MunicipioEntity> GetCompleteIBGE (int codIBGE)
        {
            return await _dataset.Include(m=>m.Uf)
            .FirstOrDefaultAsync(m=>m.CodIBGE.Equals(codIBGE));
        }
        public async Task <MunicipioEntity> GetCompleteById (Guid id)
        {
            return await _dataset.Include(m=>m.Uf)
            .FirstOrDefaultAsync(m=>m.CodIBGE.Equals(id));
        }
    }
}