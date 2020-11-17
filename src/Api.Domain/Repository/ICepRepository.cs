using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System.Threading.Tasks;
namespace Api.Domain.Repository
{
    public interface ICepRepository : IRepository<CepEntity>
    {
          Task<CepEntity> SelectAsync(string cep);
    }
}   