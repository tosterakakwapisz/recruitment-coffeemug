using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZadaniePraca.Models
{
    public class ProductUpdateInputModel : Product
    {
        public ProductUpdateInputModel(Guid id, string name, decimal price)
            :base(id,name,price)
        {

        }
    }
}
