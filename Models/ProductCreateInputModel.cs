using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZadaniePraca.Models
{
    public class ProductCreateInputModel : Product
    {
        public ProductCreateInputModel(string name, decimal price)
            : base(name,price)
        {
        }
    }
}
