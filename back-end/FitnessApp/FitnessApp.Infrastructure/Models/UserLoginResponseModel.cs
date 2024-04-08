using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Infrastructure.Models
{
    public class UserLoginResponseModel
    {
        public string? Token { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsAuthenticationSuccess { get; set; }=false;
    }
}
