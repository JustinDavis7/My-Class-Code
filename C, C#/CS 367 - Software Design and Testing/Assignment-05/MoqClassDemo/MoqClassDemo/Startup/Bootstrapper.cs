using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MoqClassDemo.Services;

namespace MoqClassDemo.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<JsonDataStore>()
                .As<IDataStore>();

            return builder.Build();
        }
    }
}
