using Final.Models;

namespace Final.DAL
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(WCDbContext ctx) : base(ctx)
        { }

        public List<Player> GetPositionPlayers(string countryAbbreviation, string position)
        {
            // **********************************************
            // Put your implementation here
            // **********************************************
            if(countryAbbreviation == null || position == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                try
                {
                    var team = GetAll().ToList().Where(t => t.Abbreviation.ToLower() == countryAbbreviation.ToLower());
                    var temp = team.First().Players.ToList();
                    var players = new List<Player>();
                    foreach(var player in temp)
                    {
                        if(player.Position.Name.ToLower() == position.ToLower())
                        {
                            players.Add(player);
                        }
                    }
                    return players.OrderBy(g => g.FullName).ToList();
                }
                catch
                {
                    return new List<Player>();
                }
            }
            return null;
        }

        public Country? CountryExists(string countryAbbreviation)
        {
            
            // **********************************************
            // Put your implementation here
            // **********************************************
            var teams = GetAll().ToList();
            foreach(var team in teams)
            {
                if (team.Abbreviation.ToLower() == countryAbbreviation.ToLower())
                {
                    return team;
                }
            }
            return null;
        }

        // **********************************************
        // These are provided for you for the last problem
        // **********************************************
        public int CurrentWins(int id)
        {
            Country? c = GetAll(c => c.Id == id).FirstOrDefault();
            if(c == null)
            {
                throw new ArgumentException("id not found");
            }

            int homeWins = c.MatchResultHomeTeams.Where(mr => mr.HomeTeamGoals > mr.AwayTeamGoals).Count();
            int awayWins = c.MatchResultAwayTeams.Where(mr => mr.AwayTeamGoals > mr.HomeTeamGoals).Count();
            return homeWins + awayWins;
        }

        public int CurrentLosses(int id)
        {
            Country? c = GetAll(c => c.Id == id).FirstOrDefault();
            if (c == null)
            {
                throw new ArgumentException("id not found");
            }

            int homeLosses = c.MatchResultHomeTeams.Where(mr => mr.HomeTeamGoals < mr.AwayTeamGoals).Count();
            int awayLosses = c.MatchResultAwayTeams.Where(mr => mr.AwayTeamGoals < mr.HomeTeamGoals).Count();
            return homeLosses + awayLosses;
        }

        public int CurrentDraws(int id)
        {
            Country? c = GetAll(c => c.Id == id).FirstOrDefault();
            if (c == null)
            {
                throw new ArgumentException("id not found");
            }

            int homeDraws = c.MatchResultHomeTeams.Where(mr => mr.HomeTeamGoals == mr.AwayTeamGoals).Count();
            int awayDraws = c.MatchResultAwayTeams.Where(mr => mr.AwayTeamGoals == mr.HomeTeamGoals).Count();
            return homeDraws + awayDraws;
        }
    }
}
