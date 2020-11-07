using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Api.Domain.Interfaces.User;
    using Api.Domain.Dto;
    using Microsoft.AspNetCore.Authorization;
    using System.Net;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    namespace Api.Application.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]  
        public class LoginController : ControllerBase
        {
            [AllowAnonymous]
            [HttpPost]
            public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
            {
                if (!ModelState.IsValid)
                {
                   return BadRequest(ModelState);
                }
                if (loginDto == null)
                {
                return BadRequest();
                }
                try
               {
                var result = await service.FindByLogin(loginDto);
                if (result != null)
                {
                    return  Ok(result);
                }   
                else
                {
                    return NotFound();
                }
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
     
        }
    }
}


