using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZadaniePraca.Models
{
    public class Product
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Product price (decimal)
        /// </summary>
        public decimal Price { get; private set; }

        /// <param name="id">Product ID</param>
        /// <param name="name">Product name</param>
        /// <param name="price">Product price</param>
        public Product(Guid id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        /// <param name="name">Product name</param>
        /// <param name="price">Product price</param>
        public Product(string name, decimal price)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
        }

        public void SetName(string name) => this.Name = name;
        public void SetPrice(decimal price) => this.Price = price;
    }
}