using Final.Models;

namespace Final.DAL
{
    public interface ICountryRepository : IRepository<Country>
    {

        /// <summary>
        /// Find out if a country exists in the db
        /// </summary>
        /// <param name="countryAbbreviation">Abbreviation of the country, e.g. ARG, FRA, or USA.  Not case sensitive.</param>
        /// <returns>The country if it exists, null otherwise</returns>
        /// <throws>Throws ArgumentNullException if the country abbreviation argument is null</throws>
        Country? CountryExists(string countryAbbreviation);


        /// <summary>
        /// Get a list of players who play a particular position, for a particular country
        /// </summary>
        /// <param name="countryAbbreviation">Abbreviation of the country, e.g. ARG, FRA, or USA.  Not case sensitive.</param>
        /// <param name="position">Position the player plays, e.g. Goalkeeper, Defender, etc. Not case sensitive.</param>
        /// <returns>List of players, sorted alphabetically by name</returns>
        /// <throws>Throws ArgumentNullException if either argument is null</throws>
        List<Player> GetPositionPlayers(string countryAbbreviation, string position);

        /// <summary>
        /// Current number of wins.
        /// </summary>
        /// <param name="id">Id of the country</param>
        /// <returns>Number of wins</returns>
        int CurrentWins(int id);

        /// <summary>
        /// Current number of losses.
        /// </summary>
        /// <param name="id">Id of the country</param>
        /// <returns>Number of losses</returns>
        int CurrentLosses(int id);

        /// <summary>
        /// Current number of draws.
        /// </summary>
        /// <param name="id">Id of the country</param>
        /// <returns>Number of draws</returns>
        int CurrentDraws(int id);

    }
}
