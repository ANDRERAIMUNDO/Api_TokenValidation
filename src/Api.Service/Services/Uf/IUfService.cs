using System.Threading.Tasks;
using System;
using Api.Domain.Dto.Uf;
using System.Collections.Generic;
namespace Api.Service.Services.Uf
{
    public interface IUfService
    {
        Task<UfDto> Get (Guid id);
        Task<IEnumerable<UfDto>> GetAll();
    }
}