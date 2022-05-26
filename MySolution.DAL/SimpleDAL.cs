using Microsoft.Extensions.Configuration;
using MySolution.Model;
using System.Data;
using System.Data.SqlClient;

namespace MySolution.DAL
{
    public class SimpleDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SimpleDAL()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();

            this._connectionString = this._configuration.GetConnectionString("Default");
        }

        public void SaveArgumentsSumResult(ArgumentsSumResult argumentsSumResult)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand($"INSERT INTO dbo.ArgumentsSumResults(ArgumentFirst, ArgumentSecond, Sum) VALUES(@ArgumentFirst, @ArgumentSecond, @Sum)", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("ArgumentFirst", argumentsSumResult.ArgumentFirst));
                command.Parameters.Add(new SqlParameter("ArgumentSecond", argumentsSumResult.ArgumentSecond));
                command.Parameters.Add(new SqlParameter("Sum", argumentsSumResult.Sum));
                connection.Open();
                command.ExecuteScalar();
                connection.Close();
            }
        }
    }
}