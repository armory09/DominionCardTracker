using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;
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

        public void Insert(CardModifier cardModifier)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardId", cardModifier.CardId);
                p.Add("@ModifierTypeId", cardModifier.ModifierTypeId);
                p.Add("@ModifierValue", cardModifier.ModifierValue);
                p.Add("@InstructionText", cardModifier.InstructionText);

                connection.Execute("CardModifierInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int cardModifierId)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CardModifierId", cardModifierId);

                connection.Execute("CardModifierDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
