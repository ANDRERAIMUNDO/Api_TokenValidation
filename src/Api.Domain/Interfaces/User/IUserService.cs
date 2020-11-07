using System.Collections.Generic;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Api.Domain.Dto.User;
namespace Api.Domain.Interfaces.User
{
    public interface IUserService
    {
        Task<UseDto> Get (Guid Id);
        Task<IEnumerable<UseDto>> GetAll();
        Task<UseDtoCreateResult> Post(UseDtoCreateResult user);
        Task<UseDtoUpdateResult> Put(UseDtoUpdateResult user);
        Task<bool> Delete(Guid id);
    }
}