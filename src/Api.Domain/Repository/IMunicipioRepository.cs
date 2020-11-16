using System;
using Api.Domain.Interfaces;
using Api.Domain.Entities;
using System.Threading.Tasks;
namespace Api.Domain.Repository
{
    public interface IMunicipioRepository : IRepository <MunicipioEntity>
    {
         Task<MunicipioEntity> GetCompleteById (Guid id);

         Task<MunicipioEntity> GetCompleteIBGE (int codIBGE);
    }
}