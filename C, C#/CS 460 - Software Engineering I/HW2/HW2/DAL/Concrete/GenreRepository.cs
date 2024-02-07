using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HW2.DAL.Abstract;
using HW2.Models;

namespace HW2.DAL.Concrete;

public class GenreRepository : IGenreRepository
{
    private readonly DbSet<Genre> _genres;
    public readonly IQueryable<string> genreList;

    public GenreRepository(StreamingDatabaseDbContext context)
    {
        _genres = context.Genres;
        genreList = _genres.Select(g => g.GenreString);
    }

    public IQueryable<string> GetGenreList()
    {
        return genreList;
    }

    public IList<Genre> Top5GenresDescending()
    {
        return _genres.OrderByDescending(g => g.GenreAssignments.Count()).Take(5).ToList();
    }
}