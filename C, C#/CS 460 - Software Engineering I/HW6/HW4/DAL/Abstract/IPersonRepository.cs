using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HW4.Models;
using HW4.DAL.Concrete;

namespace HW4.DAL.Abstract
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetPersonInfo(string personName);
    }
}