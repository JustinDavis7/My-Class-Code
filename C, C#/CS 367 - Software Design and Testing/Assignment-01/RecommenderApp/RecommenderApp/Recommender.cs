using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderApp
{
    class Recommender
    {
        private readonly IList<User> _memberList = new List<User>();
        private readonly IList<Book> _books = new List<Book>();

        public Recommender()
        {
            ReadAccounts();
        }

        public bool SignIn(string userName)
        {
            foreach (var member in _memberList)
                if (member.UserName == userName)
                    return true;   
            return false;
        }
        private void ReadAccounts()
        {
            var books = File.ReadAllLines("books.txt");
            var ratings = File.ReadAllLines("ratings.txt");
            List<string> author = new List<string>();
            List<string> bookName = new List<string>();
            List<string[]> ratingString = new List<string[]>();

            int i = 0;
            string[] temp;
            foreach (var rating in ratings)
            {
                if (i > 0 && i % 2 > 0 || i == 1)
                {
                    temp = rating.Split();
                    ratingString.Add(temp);
                }
                else
                {
                    _memberList.Add(new User(rating)); //rating is actually the user name here
                }
                i++;
            }
            foreach (var book in books)
            {
                _books.Add(new Book
                {
                    Author = book.Split(',')[0],
                    Name = book.Split(',')[1],
                    Ratings = new List<Rating>()
                });
            }
            int[] temp2 = new int[ratingString[0].Count()];
            List<Rating> rTemp = new List<Rating>();
            i = 0;
            for (int p = 0; p < ratingString.Count; p++)
            {
                for (int j = 0; j < ratingString[p].Length - 1; j++)
                {
                    temp2[j] = Convert.ToInt32(ratingString[p][j]);
                }
                
                foreach (var item in temp2)
                {
                    switch (item)
                    {
                        case -5:
                            rTemp.Add(Rating.Hatedit);
                            break;
                        case -3:
                            rTemp.Add(Rating.Didntlikeit);
                            break;
                        case 0:
                            rTemp.Add(Rating.Haventreadit);
                            break;
                        case 1:
                            rTemp.Add(Rating.OK);
                            break;
                        case 3:
                            rTemp.Add(Rating.Likedit);
                            break;
                        case 5:
                            rTemp.Add(Rating.Reallylikedit);
                            break;
                    }
                }
                _memberList[p].Ratings = new List<Rating>(rTemp);
                for (i = 0; i < rTemp.Count() - 1; ++i)
                {
                    _books[i].Ratings.Add(rTemp[i]);
                }
                rTemp.Clear();
            }
        }

        public string GetSuggestions(string userName, int choice)
        {
            var userRatings = new List<Rating>();
            var memberRatings = new List<List<Rating>>();

            foreach (var member in _memberList)
            {
                if (member.UserName == userName)
                {
                    userRatings = member.Ratings;
                }
                else
                    memberRatings.Add(member.Ratings);
            }
            var temp = this.PairWiseCalculations(userRatings, memberRatings); 
            switch (choice)
            {
                case 1:
                    return temp[0];
                    break;
                case 2:
                    return temp[1];
                    break;
            }
            return "";
        }
        public List<string> PairWiseCalculations(List<Rating> userRatings, List<List<Rating>> memberRatings)
        {
            string recommendedReadBooks ="";
            string recommendedStayAwayBooks = "";
            int placeHolder = 0;
            int j = 0;
            List<int> comparisons = new List<int>();
            for(int i = 0; i < memberRatings.Count() - 1; ++i)
            {
                for (j = 0; j < memberRatings[i].Count() - 1; ++j)
                    placeHolder += ((int)userRatings[j] * (int)memberRatings[i][j]);
                comparisons.Add(placeHolder);
                placeHolder = 0;
            }
            int max = comparisons.Max();
            int min = comparisons.Min();
            for (int i = 0; i < comparisons.Count() - 1; ++i)
            {
                if (max == comparisons[i])
                {
                    j = 0;
                    foreach (var rate in memberRatings[i])
                    {
                        if ((int)rate == 5 && userRatings[j] == 0)
                        {
                            recommendedReadBooks += $"{_books[j].Name}, ";
                        }
                        j++;
                    }
                }
                if (min == comparisons[i])
                {
                    j = 0;
                    foreach (var rate in memberRatings[i])
                    {
                        if ((int)rate == -5 && userRatings[j] == 0 && !recommendedReadBooks.Contains(_books[j].Name))
                        {
                            recommendedStayAwayBooks += $"{_books[j].Name}, ";
                        }
                        j++;
                    }
                }
            }
            List<string> temp = new List<string>();
            temp.Add(recommendedReadBooks.Remove(recommendedReadBooks.Length - 2, 1));
            temp.Add(recommendedStayAwayBooks.Remove(recommendedStayAwayBooks.Length - 2, 1));
            return temp;
        }
    }
}
