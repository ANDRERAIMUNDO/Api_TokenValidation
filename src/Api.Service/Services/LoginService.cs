using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Interfaces.User;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;  
using System.Collections.Generic;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        
        public SigningConfigurations _signingConfigurations;
        private IUserRepository _repository;
        private IConfiguration _configuration{get;}

        public LoginService(SigningConfigurations signingConfigurations, IUserRepository repository, IConfiguration configuration)
        {
            _signingConfigurations =signingConfigurations;
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
                var baseUser = new UserEntity();
            if(user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);
                if (baseUser ==null)
                {
                    return new 
                {
                    authenticated = false,
                    message = "falha de autenticação"
                };
            }
             else
                {
                  ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new []
                     {
                            new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim (JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                 );
                     DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));

                   var handler = new JwtSecurityTokenHandler();
                   string token  = CreateToken(identity, createDate, expirationDate, handler);
                   return SuccessObject(createDate, expirationDate, token, baseUser);
                }
 
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Erro de autentificacao"
                };
            }
        }

    private string CreateToken (ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
    {
        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = Environment.GetEnvironmentVariable("Issuer"),
            Audience = Environment.GetEnvironmentVariable("Audience"),
            SigningCredentials = _signingConfigurations.SigningCredentials,
            Subject = identity,
            NotBefore = createDate,
            Expires = expirationDate,
        }
        );

        var token = handler.WriteToken(securityToken);
        return token;
    }
    private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
    {
        return new 
        {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                name = user.Name,
                message = "user logged in successfully"
        };
    }
  }
}