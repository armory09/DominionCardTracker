using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.DataLayer.Repository
{
    public class CardSetRepository
    {
        public List<CardSet> SelectAll()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                return connection.Query<CardSet>("CardSetSelectAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Insert(CardSet cardSet)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardSetName", cardSet.CardSetName);

                connection.Execute("CardSetInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(CardSet cardSet)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardSetId", cardSet.CardSetId);
                p.Add("@CardSetName", cardSet.CardSetName);

                connection.Execute("CardSetUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int cardSetId)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardSetId", cardSetId);

                connection.Execute("CardSetDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
