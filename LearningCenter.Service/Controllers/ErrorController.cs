using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningCenter.Service.Models;

namespace LearningCenter.Service.Controllers
{
    /// <summary>
    /// This is my Error controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// This is the primary Error route
        /// </summary>
        /// <param name="code">Http Status code (int32)</param>
        /// <returns></returns>
        [Route("/error/{code}")]
        [HttpGet]
        public IActionResult Error(int code) => new ObjectResult(new ApiResponse(code));
    }
}
