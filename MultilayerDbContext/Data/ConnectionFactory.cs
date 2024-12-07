using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Multilayer_BusinessEntities.InterFaces;

namespace Multilayer_DBConnectivity.Data
{
    public class ConnectionFactory:IConnectionFactory
    {
        private readonly IConfiguration _config;

        public ConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection GetHotelManagementSqlConnection()
        {
            IDbConnection _connection = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementSqlConnectionString").Value));

            return _connection;
        }
    }
}
