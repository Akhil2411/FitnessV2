using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Dal.Constants
{
    public static class Queries
    {
        public static string FindByEmailId_Query = "SELECT COUNT(1) FROM MST_USER WHERE Email=@email";
        public static string CheckAuthentication_Query = "SELECT UserId,Email FROM MST_USER WHERE Email=@email and Password=@password";
    }
}
