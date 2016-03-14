using System.Data;
using System.Data.SqlClient;
using Dapper;
using DominionCardTracker.DataLayer;

namespace DominionCardTracker.IntegrationTest
{
    public class DatabaseResetRepository
    {
        public void ResetDatabase()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                connection.Execute("DbReset", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
