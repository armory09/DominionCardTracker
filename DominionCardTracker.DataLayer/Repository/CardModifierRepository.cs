using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Views;

namespace DominionCardTracker.DataLayer.Repository
{
    public class CardModifierRepository
    {
        public List<CardModifierView> SelectByCardId(int cardId)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardId", cardId);
                return
                    connection.Query<CardModifierView>("CardModifierSelectByCardId", p,
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
