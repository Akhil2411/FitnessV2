using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Infrastructure.Models
{
    public class UserDetailModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
