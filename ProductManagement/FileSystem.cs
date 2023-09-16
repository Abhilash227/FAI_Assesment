using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assesment
{
    class FileSystem:IProduct
    {
        static List<Product> productList = new List<Product>();
        const string file = "products.csv";
        public static void WriteRecordsToFile(Product pro)
        {
            var line = $"{pro.ProductId},{pro.ProductName},{pro.ProductPrice},{pro.ProductType}\n";
            File.AppendAllText(file, line);
            Console.WriteLine("Product added successfully");
        }
        public static List<Product> ReadRecordsFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename); 
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                var pro = new Product
                {
                    ProductId = int.Parse(words[0]),
                    ProductName = words[1],
                    ProductPrice = double.Parse(words[2]),
                    ProductType = words[3]
                };
                productList.Add(pro);
            }
            return productList;
        }

        public void AddProduct(Product pro)
        {
            productList.Add(pro);
            WriteRecordsToFile(pro);
        }

        public  Product FindProduct(int id)
        {
            productList = ReadRecordsFromFile(file);
            var found_rec = productList.Find(delegate (Product temp)
              {
                  return temp.ProductId == id;
              });
            if(found_rec!=null)
            {
                return found_rec;
            }
            return null;
        }

        public void DeleteProduct(int id)
        {
            var list = ReadRecordsFromFile(file);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ProductId == id)
                {
                    list.RemoveAt(i);
                    break;
                }
                throw new Exception
            }
            File.Delete(file);
            BulkInsertRecords(list);

        }
        public static void BulkInsertRecords(List<Product> list)
        {
            foreach (var item in list)
                WriteRecordsToFile(item);
  
        }
        public  void UpdateRecords(int id,Product pro)
        {

            var list = ReadRecordsFromFile(file);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ProductId == id)
                {
                    list[i]=pro;
                    break;
                }
            }
            File.Delete(file);
            BulkInsertRecords(productList);
        }
        public static void DisplayProductDetails(Product pro)
        {
            Console.WriteLine(pro.ProductId);
            Console.WriteLine(pro.ProductName);
            Console.WriteLine(pro.ProductPrice);
            Console.WriteLine(pro.ProductType);
        }
        public static void DisplayList()
        {
            productList = ReadRecordsFromFile(file);
            foreach (var item in productList)
                Console.WriteLine($"{item.ProductId},{item.ProductName},{item.ProductPrice},{item.ProductType}");
        }
        static void Main(string[] args)
        {
            string name, type;
            int id;
            double price;
            FileSystem obj = new FileSystem();
            Console.WriteLine("ADD PRODUCT-PRESS 1");
            Console.WriteLine("FIND PRODUCT-PRESS 2");
            Console.WriteLine("DELETE PRODUCT-PRESS 3");
            //DisplayList();
            int choice = Utilities.GetInteger("Enter the choice");
            switch(choice)
            {
                case 1:
                    id = Utilities.GetInteger("Enter the product id");
                    name = Utilities.GetString("Enter the name");
                    price = Utilities.GetDouble("Enter the price");
                    type = Utilities.GetString("Enter the type");
                    Product pro = new Product(id, name, price, type);
                    obj.AddProduct(pro);
                    break;

                case 2:
                    id = Utilities.GetInteger("Enter the product id");
                    Product prod = obj.FindProduct(id);
                    Console.WriteLine("The details of the enquired product");
                    DisplayProductDetails(prod);
                    break;

                case 3:
                    id = Utilities.GetInteger("Enter the product id");
                    //Product DelProd = obj.FindProduct(id);
                    obj.DeleteProduct(id);
                    break;
                case 4:
                    id = Utilities.GetInteger("Enter the product id");
                    name = Utilities.GetString("Enter the updated name");
                    price = Utilities.GetDouble("Enter the updated price");
                    type = Utilities.GetString("Enter the updated type");
                    Product upProd = new Product(id, name, price, type);
                    obj.UpdateRecords(id, upProd);
                    break;

                    

            }
        }
    }
}



            
