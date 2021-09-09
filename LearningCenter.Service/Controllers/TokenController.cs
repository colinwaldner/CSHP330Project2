﻿using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.Service.Controllers
{
    public class TokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Generate Tokens
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // This should require SSL
        [HttpPost]
        public dynamic Post([FromBody] TokenRequest tokenRequest)
        {
            var token = TokenHelper.GetToken(tokenRequest.UserName, tokenRequest.Password);
            return new { Token = token };
        }

        // This should require SSL
        [HttpGet]
        public dynamic Get(string userName, string password)
        {
            var token = TokenHelper.GetToken(userName, password);
            return new { Token = token };
        }
    }
}
