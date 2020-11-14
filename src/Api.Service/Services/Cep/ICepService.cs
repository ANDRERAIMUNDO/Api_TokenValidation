using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dto.Cep;
namespace Api.Service.Services.Cep
{
    public interface ICepService
    {
         Task<CepDto> Get (Guid id);
         Task<CepDto> Get (string cep);
         Task<CepDtoCreateResult> Post (CepDtoCreate cep);
         Task<CepDtoUpdateResult> Put (CepDtoUpdate cep);
         Task<bool> Delete (Guid id);
    }
}