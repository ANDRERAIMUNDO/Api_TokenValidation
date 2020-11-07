using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
namespace Api.Domain.Dto.User
{
    public class UseDtoCreate
    {
        [Required(ErrorMessage = "Nome Obrigatorio.")]
        [StringLength(60, ErrorMessage = "Nome de conter {1} caracter.")]
        public string Name {get;set;}
        [Required(ErrorMessage = "Email obrigatorio.")]
        [EmailAddress(ErrorMessage = "Email em formato errado.")]
        [StringLength(100, ErrorMessage = "Email deve possuir {1} catacter.")]
        public string Email {get;set;}
    }
}