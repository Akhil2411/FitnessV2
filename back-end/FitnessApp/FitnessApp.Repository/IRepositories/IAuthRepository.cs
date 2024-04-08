using FitnessApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Repository.IRepositories
{
    public interface IAuthRepository
    {
        Task<bool> CheckByEmailAsync(string email);
        Task<UserModel> CheckPasswordAsync(UserLoginModel model);
        Task<IEnumerable<UserDetailModel>> GetAllUsers();
    }
}
