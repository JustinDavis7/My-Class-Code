using System;
using Autofac;
using MoqClassDemo.Models;
using MoqClassDemo.Services;
using MoqClassDemo.Startup;

namespace MoqClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var dataStore = container.Resolve<IDataStore>();

            var password = new PasswordEntry()
            {
                UserName = "jondoe@gmail.com",
                Password = "Password1234!",
                SiteName = "Amazon",
                Url = "https://www.amazon.com"
            };

            Console.Write(password.Id);

            //dataStore.Add(password);

            //foreach (var passwordEntry in dataStore.GetAll())
            //{
            //    Console.WriteLine($"{passwordEntry.SiteName} {passwordEntry.Url}");
            //}
        }
    }
}
