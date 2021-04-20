using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Encodingproject.Models;
using Encodingproject.Services;
using Microsoft.AspNetCore.Mvc;

namespace Encodingproject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Admin model)
        {
            var Admin = _authenticateService.Authenticate(model.UserName, model.Password);
            if (Admin == null)
            {
                return BadRequest(new { Message = "invalid username or password" });
            }
            else
                return Ok(Admin);
        }
    }
}
