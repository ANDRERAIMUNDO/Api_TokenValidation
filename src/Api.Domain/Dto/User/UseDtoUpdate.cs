using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace Api.Domain.Dto.User
{
    public class UseDtoUpdate
    {
        [Required(ErrorMessage = "Id obrigatorio.")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name obrigatorio.")]
        [StringLength(60, ErrorMessage = "Nome deve conter {1} caracter.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email obrigatorio.")]
        [EmailAddress(ErrorMessage = "Email em formato invalido.")]
        [StringLength(100, ErrorMessage = "Email de conter {1} caracter.")]
        public string Email { get; set; }
    }
}