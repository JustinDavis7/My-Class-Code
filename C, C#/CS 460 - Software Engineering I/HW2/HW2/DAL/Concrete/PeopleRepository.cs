using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HW2.DAL.Abstract;
using HW2.Models;

// Put this in folder DAL/Concrete
namespace HW2.DAL.Concrete;

public class PeopleRepository : IPeopleRepository
{
    private DbSet<Person> _person;

    public PeopleRepository(StreamingDatabaseDbContext context)
    {
        _person = context.People;
    }

    public (string, int) HighestOccuranceActor()
    {
        var actorInfo = _person.Select(p => p.Credits.Where(c => c.Role.RoleName == "ACTOR")).OrderByDescending(c => c.Count()).First();
        var count = actorInfo.Count();
        var actorName = actorInfo.Select(p => p.Person.FullName).First();
        return (actorName, count);
    }
}
