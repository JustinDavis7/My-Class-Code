using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderApp
{
    class User
    {
        public string UserName { get; set; }
        public List<Rating> Ratings { get; set; }

        public User(string userName)
        {
            UserName = userName;
        }



        static public List<string> GetSuggestionsToAvoid(string userName)
        {
            List<string> suggestions = new List<string>();
            return suggestions;
        }
    }
}

