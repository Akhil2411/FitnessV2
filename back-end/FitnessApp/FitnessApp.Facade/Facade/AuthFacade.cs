using FitnessApp.Facade.IFacade;
using FitnessApp.Infrastructure.Models;
using FitnessApp.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Facade.Facade
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IAuthRepository _authRepository;
        public AuthFacade(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<bool> CheckByEmailAsync(string email)
        {
            try
            {
                return await _authRepository.CheckByEmailAsync(email);
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

                return await _authRepository.CheckPasswordAsync(model);
            }
            catch
            {
                throw;
            }
     
        }

        public async Task<IEnumerable<UserDetailModel>> GetAllUsers()
        {
            try
            {
                return await _authRepository.GetAllUsers();

            }catch
            {
                throw;
            }
        }

    }
}
