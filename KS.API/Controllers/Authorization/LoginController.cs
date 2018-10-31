using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KS.API.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _loginManager;
        private readonly IMapper _mapper;

        public LoginController(ILoginManager loginManager, IMapper mapper)
        {
            _loginManager = loginManager;
            _mapper = mapper;
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> Login([FromBody] ExistingUserQueryRequest userForLogin)
        {
            //userForLogin.Username = userForLogin.Username.ToLower();
            //var dto = _mapper.Map<QueryForExistingUserDTO>(userForLogin);
            //await _loginManager.LoginUser(dto);
            return Ok();
        }
    }
}