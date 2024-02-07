using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HW2.DAL.Abstract;
using HW2.Models;

// Put this in folder DAL/Concrete
namespace HW2.DAL.Concrete;

public class ShowRepository : IShowRepository
{
    private DbSet<Show> _shows;

    public ShowRepository(StreamingDatabaseDbContext context)
    {
        _shows = context.Shows;
    }

    public (int show, int movie, int tv) NumberOfShowsByType()
    {
        // Your implementation here
        return (_shows.Count(), 
                _shows.Where(m => m.ShowTypeId == 2).Count(),
                _shows.Where(m => m.ShowTypeId == 1).Count()); // this is a value tuple type, new in C# 7.0 (we're now at C# 10)
    }


    public Show HighestTMDBPopularity()
    {     
        return _shows.OrderByDescending(p => p.TmdbPopularity).First();
    }

    public Show MostIMDBVotes()
    {
        return _shows.OrderByDescending(v => v.ImdbVotes).First();
    }

    public Show Oldest()
    {
        return _shows.OrderBy(o => o.ReleaseYear).First();
    }

    public Show Newest()
    {
        return _shows.OrderByDescending(n => n.ReleaseYear).First();
    }

    public List<string> HighestRatedShowInGenre10StringList (string genre, int pickedType)
    {
        var tempList = new List<string>();
        var allShows = _shows.Select(s => s.GenreAssignments
                        .Where(g => g.Genre.GenreString == genre)
                        .Select(s => s.Show)
                        .Where(s => s.ShowTypeId == pickedType)
                        .Select(s => new {Title = s.Title, ReleaseYear = s.ReleaseYear, AgeCert = s.AgeCertification.CertificationIdentifier,  ImdbScore = s.ImdbScore, Directors = s.Credits
                        .Where(c => c.Role.RoleName == "Director").Select(c => c.Person.FullName)}))
                        .Where(s => s.Count() > 0).Take(10);
        
        foreach(var ListItem in allShows)
        {
            foreach(var show in ListItem)
            {
                var tempString = show.Title + "**" + show.ReleaseYear + "**" + show.AgeCert + "**" + show.ImdbScore;
                foreach(var director in show.Directors)
                    tempString += "**" + director;
                tempList.Add(tempString);
            }
        }
        return tempList;
    }

    public List<string[]> HighestRatedShowInGenre10Lists (List<string> shows)
    {
        var ratingTemp = new List<double>();
        var tempList = new List<string[]>();
        var returnList = new List<string[]>();
        var blankRatingCheck = 0;
        foreach(var show in shows)
        {
            var temp = show.Split("**");
            if(temp[3] == "")
            {
                tempList.Add(temp);
            }
            else
            {
                tempList.Add(temp);
                ratingTemp.Add(double.Parse(temp[3]));
            }
        }
        ratingTemp.Sort();
        foreach(var rating in ratingTemp)
        {
            foreach(var show in tempList)
            {
                if(show[3] != "")
                {
                    if(double.Parse(show[3]) == rating)
                    {
                        returnList.Add(show);
                        tempList.Remove(show);
                        break;
                    }
                }
                blankRatingCheck++;
            }
        }
        returnList.Reverse();
        if(blankRatingCheck > 0)
        {
            foreach(var show in tempList)
            {
                returnList.Add(show);
            }
        }
        
        return returnList;
    }

}