using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Dto.Municipio;
namespace Api.Service.Services.Municipio
{
    public interface IMunicipioService
    {
         Task<MunicipioDto> Get (Guid id);
         Task<MunicipioDtoCompleto> GetCompleteById (Guid id);
         Task<MunicipioDtoCompleto> GetMunicipioByIBGE (int codIBGE);
         Task<IEnumerable<MunicipioDto>> GetAll ();
         Task<MunicipioDtoCreateResult> Post (MunicipioDtoCreate municipio);
         Task<MunicipioDtoUpdateResult> Put (MunicipioDtoUpdate municipio);
         Task<bool> Delete (Guid id);
    }
}