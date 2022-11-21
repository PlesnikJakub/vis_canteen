using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Canteen.DataAccess
{
    public class MenuItemTDG
    {
        private static readonly string _tableName = "vis_menu_items";

        public DataTable GetAll()
        {
            // write down query
            var query = $"select * from {_tableName};";

            // objet for results
            var result = new DataTable();

            // get connection string 
            var connString = DBConnector.GetBuilder().ConnectionString;

            // Connect
            using (SqlConnection connection = new SqlConnection(connString))
            {
                // Open connection
                connection.Open();

                // prepare command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // execute command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // read data from result
                        result.Load(reader);
                    }
                }
            }
            return result;
        }

        public DataTable GetById(int id)
        {
            var query = $"select * from {_tableName} where id = @id;";
            var result = new DataTable();
            var connString = DBConnector.GetBuilder().ConnectionString;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
            }
            return result;
        }

        public int Create(string title, double price, bool isVegan)
        {
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var sb = new StringBuilder();
                sb.Clear();
                sb.Append($"INSERT INTO {_tableName} (title, price, is_vegan)");
                sb.Append("VALUES (@title, @price, @is_vegan);");
                sb.Append("SELECT CAST(scope_identity() AS int)");

                string sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@is_vegan", isVegan);
                    int modified = (int)command.ExecuteScalar();
                    return modified;
                }
            }
        }

        public bool Update(int id, string title, double price, bool isVegan)
        {
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var sb = new StringBuilder();
                sb.Clear();
                sb.Append($"UPDATE {_tableName} SET title = @title, price = @price, is_vegan = @is_vegan where id = @id");

                string sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@is_vegan", isVegan);
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }

        public bool Delete(int id)
        {
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var sb = new StringBuilder();
                sb.Clear();
                sb.Append($"DELETE FROM {_tableName} WHERE id = @id");

                string sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}
