using Microsoft.Data.SqlClient;

namespace AegisTest.Helpers.Database
{
    public class SqlContext
    {
        public string ConnectionString { get; set; }

        public SqlContext()
        {
            string connectionString = DBLoader.GetConnstring();
            this.ConnectionString = connectionString;
        }

        public SqlConnection GetConnection() { return new SqlConnection(ConnectionString); }
    }
}