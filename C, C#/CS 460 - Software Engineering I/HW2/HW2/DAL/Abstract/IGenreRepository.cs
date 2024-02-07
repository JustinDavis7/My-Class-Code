using HW2.Models;

namespace HW2.DAL.Abstract;

public interface IGenreRepository
{
    IList<Genre> Top5GenresDescending();

    IQueryable<string> GetGenreList();
}