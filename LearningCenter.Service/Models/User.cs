using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCenter.Service.Models
{
    public class User
    {
        /// <summary>
        /// This is my Id
        /// </summary>
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
