using System;
using System.Collections.Generic;
using System.Linq;
using HW4.Models;
using HW4.DAL.Abstract;

namespace HW4.DAL.Concrete 
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ToDoDbContext ctx) : base(ctx)
        { }
        public Person GetPersonInfo(string personName)
        {
            var people = GetAll().ToList();
            var user = new Person();
            try 
            {
                var temp = personName.Split(" ");
                var first = temp[0];
                var last = temp[1]; 
                first = char.ToUpper(first[0]) + first.Substring(1);
                last = char.ToUpper(last[0]) + last.Substring(1);
                try
                {
                    user = people
                            .Where(p => p.FirstName == first)
                            .Where(p => p.LastName == last)
                            .SingleOrDefault();
                }
                catch (NullReferenceException e)
                {
                    return user = null;
                }
            }
            catch(IndexOutOfRangeException e)
            {
                return user = null;
            }      
            return user;
        }
    }
}