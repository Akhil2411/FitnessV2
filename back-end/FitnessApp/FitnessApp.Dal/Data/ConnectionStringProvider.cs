using FitnessApp.Dal.IData;
using FitnessApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Dal.Data
{
    public class ConnectionStringProvider:IConnectionStringProvider
    {
        public string GetConnectionString()
        {
            string conString = Global.ConnectionString;
            return conString;
        }
    }
}
