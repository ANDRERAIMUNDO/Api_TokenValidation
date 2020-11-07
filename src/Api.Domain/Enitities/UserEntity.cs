using System;
namespace Api.Domain.Enitities
{
    public class UserEntity:BaseEntity
    {
        public string Name {get;set;}
        public string Email{get;set;}
    }
}