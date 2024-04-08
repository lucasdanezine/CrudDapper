using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace FiapSchool.Infrastructure.Services
{
    public class DbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return connection;
        }
    }
}
