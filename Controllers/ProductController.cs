using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZadaniePraca.Models;

namespace ZadaniePraca.Controllers
{
    public class ProductController : Controller
    {
        ProductActions product_actions = new ProductActions();

        /// <summary>
        /// Retrieves all products
        /// </summary>
        /// <returns>
        /// Returns product list
        /// </returns>
        [ActionName("GetAllProducts")]
        [HttpGet]
        public List<Product> Get()
        {
            List<Product> product_list = product_actions.GetAllProducts();
            return product_list;
        }
        
        /// <summary>
        /// Retrieves one product with given ID
        /// </summary>
        /// <param name="id">ID of product to retrieve</param>
        /// <returns>Returns product</returns>
        [HttpGet]
        public Product Get(Guid id)
        {           
            return product_actions.GetProduct(id);
        }
        
        /// <summary>
        /// Creates a product with given name and price and saves it in database
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="price"> Product price</param>
        /// <returns>Returns ID of created and saved product</returns>
        [HttpPost]
        public Guid Post(string name, decimal price)
        {
            ProductCreateInputModel product_create_input = new ProductCreateInputModel(name, price);
            return product_actions.CreateProduct(product_create_input);
        }

        /// <summary>
        /// Updates product in database with given ID
        /// </summary>
        /// <param name="id">ID of product to update</param>
        /// <param name="name">Name of product to update</param>
        /// <param name="price">Price of product to update</param>
        /// <returns>Returns true on success, false on failure</returns>
        [HttpPut]
        public bool Put(Guid id, string name, decimal price)
        {
            ProductUpdateInputModel product_update_input = new ProductUpdateInputModel(id, name, price);
            return product_actions.UpdateProduct(product_update_input);
        }

        /// <summary>
        /// Deletes product in database with given ID
        /// </summary>
        /// <param name="id">ID of product to delete</param>
        /// <returns>Returns true on success, false on failure</returns>
        [HttpDelete]
        public bool Delete(Guid id)
        {
            return product_actions.DeleteProduct(id);
        }
    }
}