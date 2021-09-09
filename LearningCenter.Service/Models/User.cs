using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCenter.Service.Models
{
    /// <summary>
    /// This is the main User model class
    /// </summary>
    public class User
    {
        /// <summary>
        /// Service generated Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User provided Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User provided hashed Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Service generated DateTime
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
