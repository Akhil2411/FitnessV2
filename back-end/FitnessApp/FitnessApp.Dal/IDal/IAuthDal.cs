using FitnessApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Dal.IDal
{
    public interface IAuthDal
    {
        Task<bool> CheckByEmailAsync(string email);
        Task<UserModel> CheckPasswordAsync(UserLoginModel model);
        Task<IEnumerable<UserDetailModel>> GetAllUsers();
    }
}
