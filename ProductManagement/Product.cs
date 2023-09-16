using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment
{
    class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string ProductType { get; set; }
    
        public Product(int id,string name,double price,string type)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            ProductType = type;
        }
        public Product()
        {

        }
    }

}
