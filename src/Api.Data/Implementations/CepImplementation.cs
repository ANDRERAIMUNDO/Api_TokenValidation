using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Api.Data.Implementations
{
    public class CepImplementation : BaseRepository <CepEntity>, ICepRepository
    {
        private DbSet <CepEntity> _dateSet;
        public CepImplementation (MyContext context) : base (context)
        {
            _dateSet = context.Set<CepEntity>();
        }
        public async Task <CepEntity> SelectAync (string cep)
        {
            return await _dateSet.Include(c=>c.Municipio)
            .ThenInclude(m=>m.Uf)
            .FirstOrDefaultAsync(u=>u.Cep.Equals(cep));
        }
    }
}