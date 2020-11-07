using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage="Email Obrigatorio")]
        [EmailAddress(ErrorMessage ="Email em formato errado.")]
        [StringLength(100, ErrorMessage ="Email deve possuir maximo {1} caracters.")]
        public string Email {get;set;}
    }
}