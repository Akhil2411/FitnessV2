using FitnessApp.Dal.IData;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Dal.Data
{
    public class DataContext:IDataContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        public DataContext(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider=connectionStringProvider;
        }

        public IDbConnection CreateConnection()
        {
           return new SqlConnection(_connectionStringProvider.GetConnectionString());
        }

        public IDbConnection getSqlConnection  
        {
            get{ 
                return new SqlConnection(_connectionStringProvider.GetConnectionString());
            }
        }


    }
}
