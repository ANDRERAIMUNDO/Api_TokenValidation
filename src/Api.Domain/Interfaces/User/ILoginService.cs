using System.Net.Mime;
using System;
using System.Threading.Tasks;
using Api.Domain.Dto;

namespace Api.Domain.Interfaces.User
{   
    public interface IName
    {
     Task<object> FindByLogin (LoginDto user);
    }
}