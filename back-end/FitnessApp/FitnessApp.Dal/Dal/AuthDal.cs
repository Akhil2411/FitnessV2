using Dapper;
using FitnessApp.Dal.Constants;
using FitnessApp.Dal.Data;
using FitnessApp.Dal.IDal;
using FitnessApp.Dal.IData;
using FitnessApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Dal.Dal
{
    public class AuthDal :DataContext, IAuthDal
    {
        public AuthDal(IConnectionStringProvider connectionStringProvider):base(connectionStringProvider)
        {
           
        }


        public async Task<bool> CheckByEmailAsync(string email)
        {
            try
            {
                var query = Queries.FindByEmailId_Query;

                var dyParam = new DynamicParameters();

                dyParam.Add("email", email, DbType.String);

                int userCount = 0;
                using (IDbConnection con = getSqlConnection)
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    userCount = await con.QueryFirstAsync<int>(query, dyParam);                   
                }

                return userCount == 0 ? false : true;

            }
            catch (Exception ex)
            {
                throw new Exception("Exception from AuthDal", ex);
            }
        }

        public async Task<UserModel> CheckPasswordAsync(UserLoginModel model)
        {
            try
            {
                var query = Queries.CheckAuthentication_Query;

                var dyParam = new DynamicParameters();

                dyParam.Add("email", model.Email, DbType.String);
                dyParam.Add("password", model.Password, DbType.String);

                UserModel? user = new UserModel();
                using (IDbConnection con = getSqlConnection)
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var userList = await con.QueryAsync<UserModel>(query, dyParam);
                    user = userList.FirstOrDefault();
                   
                }

                return user;

            }catch(Exception ex)
            {
                throw new Exception("Exception from AuthDal", ex);
            }
         
        }

        public async Task<IEnumerable<UserDetailModel>> GetAllUsers()
        {
            try
            {
                IEnumerable<UserDetailModel> users = new List<UserDetailModel>();
                using (IDbConnection con = getSqlConnection)
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var userList = await con.QueryAsync<UserDetailModel>(SPRegistry.GetAllUsers_SP);
                    users = userList.ToList();
                }

                return users;
            }catch(Exception ex)
            {
                throw new Exception("Exception from AuthDal", ex);
            }
           
        }

       
    }
}
