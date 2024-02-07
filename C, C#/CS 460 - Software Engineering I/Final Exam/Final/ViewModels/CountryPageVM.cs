using Final.Models;

namespace Final.ViewModels
{
    /* **********************************************
     * Use this viewmodel to complete the Country Index page using the CountryController
     * **********************************************
     */
    public class CountryPageVM
    {
        public Country Country { get; set; }
        public List<Player> Goalkeepers { get; set; }
        public List<Player> Defenders { get; set; }
        public List<Player> Midfielders { get; set; }
        public List<Player> Forwards { get; set; }

        public CountryPageVM(Country country, List<Player> goalkeepers, List<Player> defenders, List<Player> midfielders, List<Player> forwards)
        {
            Country = country;
            Goalkeepers = goalkeepers;
            Defenders = defenders;
            Midfielders = midfielders;
            Forwards = forwards;
        }
    }
}
