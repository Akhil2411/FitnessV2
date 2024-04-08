using FitnessApp.Dal.IDal;
using FitnessApp.Infrastructure.Models;
using FitnessApp.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Repository.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly IAuthDal _authDal;
        public AuthRepository(IAuthDal authDal)
        {
            _authDal = authDal;
        }

        public async Task<bool> CheckByEmailAsync(string email)
        {
            try
            {
                return await _authDal.CheckByEmailAsync(email);
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserModel> CheckPasswordAsync(UserLoginModel model)
        {
            try
            {
                return await _authDal.CheckPasswordAsync(model);
            }catch 
            {
                throw;
            }
            
        }
        public async Task<IEnumerable<UserDetailModel>> GetAllUsers()
        {
            try
            {
                return await _authDal.GetAllUsers();
            }catch 
            {
                throw;
            }
        
        }
    }
}
