using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ZadaniePraca.Models
{
    public class ProductActions
    {
        public const string connection_string = "Server=localhost;Database=coffeemug_task;Uid=root;Pwd=;";
        public MySqlConnection connection = new MySqlConnection(connection_string);

        /// <summary>
        /// Creates product database
        /// </summary>
        /// <param name="product_create_input">Product to insert to database</param>
        /// <returns>Returns id of inserted product</returns>
        public Guid CreateProduct(ProductCreateInputModel product_create_input)
        {
            if (product_create_input.Price <= 0)
                throw new ArgumentException("Give me correct price man...");
            if (string.IsNullOrWhiteSpace(product_create_input.Name) || product_create_input.Name.Length > 100)
                throw new ArgumentOutOfRangeException("Man, check your product name...");

            string sql_query = "INSERT INTO `products` (`PID`, `PGuid`, `PName`, `PPrice`) VALUES" +
                " (NULL, @guid, @name, @price);";
            this.connection.Open();
            MySqlCommand command = new MySqlCommand(sql_query, this.connection);
            command.Prepare();
            command.Parameters.AddWithValue("@guid", product_create_input.Id.ToString());
            command.Parameters.AddWithValue("@name", product_create_input.Name);
            command.Parameters.AddWithValue("@price", product_create_input.Price);
            command.ExecuteNonQuery();
            this.connection.Close();
            return product_create_input.Id;
        }
        
        /// <summary>
        /// Retrieves all products from database
        /// </summary>
        /// <returns>Returns product list</returns>
        public List<Product> GetAllProducts()
        {
            List<Product> product_list = new List<Product>();

            string sql_query = "SELECT `PGuid`,`PName`,`PPrice` FROM `products`";
            this.connection.Open();
            DataTable data_from_database = new DataTable();
            MySqlDataAdapter data_adapter = new MySqlDataAdapter(sql_query, this.connection);
            data_adapter.Fill(data_from_database);
            foreach (DataRow row in data_from_database.Rows)
            {
                Guid id_buffer = new Guid(row.ItemArray[0].ToString());
                string name_buffer = row.ItemArray[1].ToString();
                decimal price_buffer = decimal.Parse(row.ItemArray[2].ToString());
                product_list.Add(new Product(id_buffer, name_buffer, price_buffer));
            }
            this.connection.Close();
            return product_list;
        }

        /// <summary>
        /// Retrieves one product from database
        /// </summary>
        /// <param name="id">Id of loaded product</param>
        /// <returns>Returns product from database on success, null on failure</returns>
        public Product GetProduct(Guid id)
        {
            List<Product> product_list = GetAllProducts();

            // check by LINQ if there is Product with given id
            if (product_list.Exists(x => ((Guid)x.Id).Equals(id)))
            {
                return product_list.First(x => x.Id.Equals(id));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Updates data of product in database
        /// </summary>
        /// <param name="product_update_input">Product to update in database</param>
        /// <returns>True on success, false on failure</returns>
        public bool UpdateProduct(ProductUpdateInputModel product_update_input)
        {
            try
            {
                string sql_query = "UPDATE `products` SET `PName` = @name, `PPrice` = @price " +
                "WHERE `products`.`PGuid` = @guid;";
                this.connection.Open();
                MySqlCommand command = new MySqlCommand(sql_query, this.connection);
                command.Prepare();
                command.Parameters.AddWithValue("@guid", product_update_input.Id);
                command.Parameters.AddWithValue("@name", product_update_input.Name);
                command.Parameters.AddWithValue("@price", product_update_input.Price);
                command.ExecuteNonQuery();
                this.connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes product from database with given ID
        /// </summary>
        /// <param name="id">ID of product to delete from database</param>
        /// <returns>True on success, false on failure</returns>
        public bool DeleteProduct(Guid id)
        {
            try
            {
                string sql_query = "DELETE FROM `products` WHERE `products`.`PGuid` = @guid;";
                this.connection.Open();
                MySqlCommand command = new MySqlCommand(sql_query, this.connection);
                command.Prepare();
                command.Parameters.AddWithValue("@guid", id);
                command.ExecuteNonQuery();
                this.connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
