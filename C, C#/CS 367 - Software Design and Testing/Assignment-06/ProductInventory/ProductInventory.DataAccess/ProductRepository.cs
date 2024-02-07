using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ProductInventory.Model;

namespace ProductInventory.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private const string StorageFile = "Database.txt";
        public IList<Product> FindAll()
        {
            var products = new List<Product>();
            var data = File.ReadAllLines(StorageFile);
            string[] split_data;
            foreach (var line in data)
            {
                split_data = line.Split(';');
                products.Add(new Product(){Id = Int32.Parse(split_data[0]), Name = split_data[1], Price = Convert.ToDecimal(split_data[2])});
            }

            return products;
        }

        public Product FindByName(string productName)
        {
            return this.FindAll().FirstOrDefault(product => productName == product.Name);
        }

        public Product FindById(int productId)
        {
            return this.FindAll().FirstOrDefault(product => productId == product.Id);
        }

        public bool Save(Product target)
        {
            var products = this.FindAll();
            var data = "";
            foreach (var product in products)
            {
                if (product.Id == target.Id)
                {
                    product.Name = target.Name;
                    product.Price = target.Price;
                }

                data += product.ToString() + "/n";
            }
            File.WriteAllText(StorageFile, data);
            return true;
        }
    }
}
