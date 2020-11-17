using System.Threading.Tasks;
using System;
using Api.Domain.Dto.Uf;
using System.Collections.Generic;
namespace Api.Domain.Interfaces.Services.Uf
{
    public interface IUfService
    {
        Task<UfDto> Get (Guid id);
        Task<IEnumerable<UfDto>> GetAll();
    }
}