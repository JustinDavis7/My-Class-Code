using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderApp
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public List<Rating> Ratings { get; set;  }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Ratings.Count() - 1; ++i)
            {
                s += $"{(int)Ratings[i]},";
            }
            return $"{Name}, {Author}, \n{s}\n";
        }
    }
}
