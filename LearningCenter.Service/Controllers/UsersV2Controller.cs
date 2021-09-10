using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningCenter.Service.Models;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningCenter.Service.Controllers
{
    /// <summary>
    /// This is my User controller
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GETONLY")]
    //[Authenticator]
    public class UsersV2Controller : ControllerBase
    {
        /// <summary>
        /// Get user (id)
        /// </summary>
        /// <param name="id">User id (int32)</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new User2
            { 
                Id = 999,
                Age = 24,
                Name = "Colin"
            });
        }

    }
    public class User2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
