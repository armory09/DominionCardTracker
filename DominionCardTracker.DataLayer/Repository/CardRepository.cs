using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;
using DominionCardTracker.Models.Views;

namespace DominionCardTracker.DataLayer.Repository
{
    public class CardRepository
    {
        public IEnumerable<Card> SelectAll()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                return connection.Query<Card>("CardSelectAll", commandType: CommandType.StoredProcedure);
            }
        }

        public Card Insert(Card card)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardSetId", card.CardSetId);
                p.Add("@CardTitle", card.CardTitle);
                p.Add("@CardCost", card.CardCost);
                p.Add("@ImagePath", card.ImagePath);
                p.Add("@CardId", null, dbType: DbType.Int32, direction:ParameterDirection.Output);

                connection.Execute("CardInsert", p, commandType: CommandType.StoredProcedure);
                card.CardId = p.Get<int>("@CardId");
            }
            return card;
        }

        public void Delete(int cardId)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardId", cardId);

                connection.Execute("CardDelete", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Card card)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardId",card.CardId);
                p.Add("@CardSetId", card.CardSetId);
                p.Add("@CardTitle", card.CardTitle);
                p.Add("@CardCost", card.CardCost);
                p.Add("@ImagePath", card.ImagePath);

                connection.Execute("CardUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Card> SelectById(int id)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardId",id);
                return connection.Query<Card>("CardSelectById", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public CardView SelectView(int cardId)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CardId", cardId);

                using (var multi = connection.QueryMultiple("CardSelectView",p,commandType:CommandType.StoredProcedure))
                {
                    CardView view = multi.Read<CardView>().Single();
                    view.Categories = multi.Read<Category>().ToList();
                    view.Modifiers = multi.Read<CardModifierView>().ToList();

                    return view;
                }
            }
        }
    }
}
