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
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GETONLY")]
    //[Authenticator]
    public class UsersController : ControllerBase
    {
        private static int CurrentId = 1;
        private static List<User> _users = new List<User>();

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            if (_users.Count == 0)
            {
                _users.Add(new User { Id = CurrentId++, CreateDate = DateTime.UtcNow, Email = "admin@email.com", Password = "Password1234" });
                _users.Add(new User { Id = CurrentId++, CreateDate = DateTime.UtcNow, Email = "user1@email.com", Password = "Password123" });
                _users.Add(new User { Id = CurrentId++, CreateDate = DateTime.UtcNow, Email = "user2@email.com", Password = "Password234" });
                _users.Add(new User { Id = CurrentId++, CreateDate = DateTime.UtcNow, Email = "user3@email.com", Password = "Password134" });
            }
            return _users;
        }


        /// <summary>
        /// Get user (id)
        /// </summary>
        /// <param name="id">User id (int32)</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return new ObjectResult(new ApiResponse(404));
            }

            return Ok(user);
        }
        [HttpGet]
        [Route("{id}/orders")]
        public IActionResult GetContactOrders(int id)
        {            
            return Ok(new User
            {
                Id = 99,
                Email = "BOO",
                Password = "NANA",
                CreateDate = DateTime.Now
            });
        }

        /// <summary>
        /// Add user (email, password)
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return new ObjectResult(new ApiResponse(400));
            }

            if (user.Email == null || user.Password == null)
            {
                return new ObjectResult(new ApiResponse(400));
            }

            user.Id = CurrentId++;
            user.CreateDate = DateTime.UtcNow;
            _users.Add(user);

            return CreatedAtAction(nameof(Get), new { Id = user.Id, CreatedDate = user.CreateDate }, user);
        }

        /// <summary>
        /// Update user (email, password)
        /// </summary>
        /// <param name="id">User id (int32)</param>
        /// <param name="update_user">User object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User update_user)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return new ObjectResult(new ApiResponse(404));
            }

            if (update_user == null)
            {
                return new ObjectResult(new ApiResponse(400));
            }

            if (update_user.Email == null || update_user.Password == null)
            {
                return new ObjectResult(new ApiResponse(400));
            }

            user.Email = update_user.Email;
            user.Password = update_user.Password;

            return Ok(user);
        }

        /// <summary>
        /// Delete user (id)
        /// </summary>
        /// <param name="id">User id (int32)</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return new ObjectResult(new ApiResponse(404));
            }

            _users.RemoveAll(x => x.Id == id);

            return new OkResult();
        }
    }
}
