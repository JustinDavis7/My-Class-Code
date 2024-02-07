using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoqClassDemo.Logic;
using MoqClassDemo.Models;

namespace MoqClassDemo.Test
{
    public abstract class PasswordManagerTestBase
    {
        protected PasswordManager PasswordManager;
        protected readonly PasswordEntry GoodPassword = new()
        {
            UserName = "jondoe@gmail.com",
            Password = "Password1234!",
            SiteName = "Amazon",
            Url = "https://www.amazon.com"
        };

        protected readonly PasswordEntry BadPassword = new()
        {
            UserName = "jondoe@gmail.com",
            Password = "lard",
            SiteName = "Walmart",
            Url = "https://www.walmart.com"
        };

        protected PasswordManagerTestBase(PasswordManager passwordManager) => PasswordManager = passwordManager;

    }
}
