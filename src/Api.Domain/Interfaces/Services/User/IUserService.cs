using System.Collections.Generic;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Api.Domain.Dto.User;
namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UseDto> Get (Guid Id);
        Task<IEnumerable<UseDto>> GetAll();
        Task<UseDtoCreateResult> Post(UseDtoCreate user);
        Task<UseDtoUpdateResult> Put(UseDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}