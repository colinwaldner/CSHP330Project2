using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningCenter.Service.Models;

namespace LearningCenter.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error/{code}")]
        [HttpGet]
        public IActionResult Error(int code) => new ObjectResult(new ApiResponse(code));
    }
}
