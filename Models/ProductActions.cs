using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZadaniePraca.Models
{
    public class ProductActions
    {
        public const string FILENAME = "database.txt";

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

            List<string> serialized_product = new List<string>()
            {
                product_create_input.Id.ToString(),
                product_create_input.Name,
                product_create_input.Price.ToString()
            };

            File.AppendAllLines(FILENAME,serialized_product);
            return product_create_input.Id;
        }
        
        /// <summary>
        /// Retrieves all products from database
        /// </summary>
        /// <returns>Returns product list</returns>
        public List<Product> GetAllProducts()
        {
            List<Product> product_list = new List<Product>();

            if (!ValidateFile(FILENAME))
                return null;

            string[] file_content = File.ReadAllLines(FILENAME);

            for (int i = 0; i < file_content.Length; i += 3)
            {
                Guid current_product_id = Guid.Parse(file_content[i]);
                string current_name = file_content[i + 1];
                decimal current_price = decimal.Parse(file_content[i + 2].Replace('.', ','));
                Product product = new Product(current_product_id, current_name, current_price);
                product_list.Add(product);
            }

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
            bool is_success = false;
            List<string> product = new List<string>()
            {
                product_update_input.Id.ToString(),
                product_update_input.Name,
                product_update_input.Price.ToString()
            };

            List<Product> product_list = GetAllProducts();
            if (product_list.Any(x => x.Id.Equals(product_update_input.Id)))
            {
                Product product_to_update = product_list.First(x => x.Id.Equals(product_update_input.Id));
                product_to_update.SetName(product_update_input.Name);
                product_to_update.SetPrice(product_update_input.Price);
                SaveAllProducts(product_list);
                is_success = true;
            }
            return is_success;
        }

        /// <summary>
        /// Deletes product from database with given ID
        /// </summary>
        /// <param name="id">ID of product to delete from database</param>
        /// <returns>True on success, false on failure</returns>
        public bool DeleteProduct(Guid id)
        {
            List<Product> product_list = GetAllProducts();

            bool is_success = false;

            if (product_list.Any(x => x.Id.Equals(id)))
            {
                Product product_to_delete = product_list.First(x => x.Id.Equals(id));
                product_list.Remove(product_to_delete);
                SaveAllProducts(product_list);
                is_success = true;
            }

            return is_success;
        }

        /// <summary>
        /// Adds serialized item to database
        /// </summary>
        /// <param name="product_input">Item to add to database which will be serialized</param>
        /// <returns>True on success, false on failure</returns>
        public bool SaveProduct(Product product_input)
        {
            if (product_input.Price <= 0)
                throw new ArgumentException("Give me correct price man...");
            if (string.IsNullOrWhiteSpace(product_input.Name) || product_input.Name.Length > 100)
                throw new ArgumentOutOfRangeException("Man, check your product name...");

            try
            {
                List<string> serialized_product = new List<string>()
                {
                    product_input.Id.ToString(),
                    product_input.Name,
                    product_input.Price.ToString()
                };

                File.AppendAllLines(FILENAME, serialized_product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Saves product list to database
        /// </summary>
        /// <param name="products_to_save">Product list to save</param>
        /// <returns>True on success, false on failure</returns>
        private bool SaveAllProducts(List<Product> products_to_save)
        {
            try
            {
                // Clears the file
                File.WriteAllText(FILENAME,string.Empty);
                products_to_save.ForEach(x => SaveProduct(x));
                return true;
            }
            catch
            {                
                return false;
            }
        }

        /// <summary>
        /// Validates file with given name
        /// </summary>
        /// <param name="file_name">Name of the file</param>
        /// <returns>True on success, false on failure</returns>
        private bool ValidateFile(string file_name)
        {
            // check if file exists
            if (!File.Exists(file_name))
                return false;

            // check if data in file are complete
            if (File.ReadAllLines(file_name).Length % 3 != 0)
                return false;

            return true;
        }
        
    }
}
