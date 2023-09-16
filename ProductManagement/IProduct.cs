using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment
{
    interface IProduct
    {
          void AddProduct(Product pro);
          Product FindProduct(int id);
          void DeleteProduct(int id);
          void UpdateRecords(int id, Product pro);

          




    }
}
