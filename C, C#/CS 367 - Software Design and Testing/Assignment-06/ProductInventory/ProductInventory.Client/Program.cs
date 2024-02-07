using ProductInventory.DataAccess;
using System;
using Autofac;
using ProductInventory.Client.Startup;

namespace ProductInventory.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bootStrapper = new BootStrapper();
            var container = bootStrapper.BootStrap();
            var repository = container.Resolve<IProductRepository>();
            foreach (var product in repository.FindAll())
            {
                Console.WriteLine(product);
            }
            Console.ReadKey();
        }
    }
}
