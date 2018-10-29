using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KS.API.DataContract.Authorization;
using KS.Business.Managers.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KS.API.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly RegisterUserManager _registerUserManager;

        public RegisterController(RegisterUserManager registerUserManager)
        {
            _registerUserManager = registerUserManager;
        }
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register([FromBody] NewUserCreateRequest userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();
            await _registerUserManager.RegisterUser(userForRegister);
            return StatusCode(201);
        }
    }
}
