using System;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Dto.Municipio
{
    public class MunicipioDtoUpdate
    {        
        [Required(ErrorMessage="Id é campo obrigatorio")]
        public Guid Id {get;set;}

        [Required(ErrorMessage="Municipio é camopo obrigatorio")]
        [StringLength(60, ErrorMessage="Nome Municipio de deve ter maximo {1} caracter")]
        public string Nome {get;set;}

        [Range(0, int.MaxValue, ErrorMessage="Codigo do IBGE invalido")]
        public int CodIBGE {get;set;}

        [Required(ErrorMessage="Coigo de UFé campo obrigatorio")]
        public Guid UfId {get;set;}
    }
}