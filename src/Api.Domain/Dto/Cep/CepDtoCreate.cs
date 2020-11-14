using System;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Dto.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage="Cep é campo obrigatorio")]
        public string Cep {get;set;}

        [Required(ErrorMessage="Logradouro é campo obrigatorio")]
        public string Logradouro {get;set;}
        public string Numero {get;set;}
       
       [Required(ErrorMessage="Municipio é campo obrigatorio")]
        public Guid MunicipioId {get;set;}
    }
}