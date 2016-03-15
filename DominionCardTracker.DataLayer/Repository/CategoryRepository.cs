using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.DataLayer.Repository
{
    public class CategoryRepository
    {
        public List<Category> SelectAll()
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                return
                    connection.Query<Category>("CategorySelectAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Insert(Category category)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CategoryName", category.CategoryName);

                connection.Execute("CategoryInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Category category)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CategoryId", category.CategoryId);
                p.Add("@CategoryName", category.CategoryName);

                connection.Execute("CategoryUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public Category Select(int categoryId)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CategoryId", categoryId);

                return connection.Query<Category>("CategorySelectById", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void Delete(int categoryId)
        {
            using (var connection = new SqlConnection(ConfigurationSettings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CategoryId", categoryId);

                connection.Execute("CategoryDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
