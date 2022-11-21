using System.Data;
using System.Data.SqlClient;

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
    }
}
