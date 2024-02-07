using HW2.Models;

// Here is a starting point to help you use a good testable design for your application logic

// Put this in a DAL/Abstract folder (DAL stands for Data Access Layer)
namespace HW2.DAL.Abstract;

public interface IShowRepository
{
    /// <summary>
    /// Get the number of shows in the DB by type
    /// </summary>
    /// <returns>Total number of shows, number of movies, number of TV shows</returns>
    (int show, int movie, int tv) NumberOfShowsByType();

    /// <summary>
    /// Get the show with the highest TMDB Popularity
    /// </summary>
    /// <returns>The show with the highest TMDB popularity</returns>
    Show HighestTMDBPopularity();

    /// <summary>
    /// Get the Show with the most IMDB votes
    /// </summary>
    /// <returns>The show having the most IMDB votes</returns>
    Show MostIMDBVotes();

    /// <summary>
    /// Get the show in the DB with the oldest Release Year
    /// </summary>
    /// <returns>The show having the oldest release year, or any one of many with the same oldest release year</returns>
    Show Oldest();

    /// <summary>
    /// Get the show in the DB with the newest Release Year
    /// </summary>
    /// <returns>The show having the most recent release year, or any one of many with the same newest release year</returns>
    Show Newest();

    /// <summary>
    /// Gets the 10 highest rated shows for the selected genre
    /// </summary>
    /// <returns>Comma seperated string that consists of the Title, Relase Year, Age Certification, Imdb Score, and the Directors</returns>
    List<string> HighestRatedShowInGenre10StringList (string genre, int pickedType);

    /// <summary>
    /// Splits up the show results for indexing
    /// </summary>
    /// <returns>List of lists containing the strings of show info for display</returns>
    List<string[]> HighestRatedShowInGenre10Lists (List<string> shows);
}