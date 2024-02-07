using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ProductInventory.DataAccess;

namespace ProductInventory.Client.Startup
{
    public class BootStrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProductRepositoryMock>().As<IProductRepository>();
            return builder.Build();
        }
    }

}
