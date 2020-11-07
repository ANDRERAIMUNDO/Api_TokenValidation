using System;
namespace Api.Domain.Dto.User
{
    public class UseDto
    {
        public Guid Id {get;set;}
        public string Email {get;set;}
        public string Name {get;set;}
        public DateTime CreateAt {get;set;}
    }
}