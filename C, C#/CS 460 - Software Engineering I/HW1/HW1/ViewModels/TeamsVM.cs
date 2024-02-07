using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HW1.ViewModels
{
    public class TeamsVM 
    {
        [Required]
        [DisplayName("TeamNames")]
        public string TeamNames {get; set;}

        [Required]
        [RegularExpression(@"^[a-zA-Z,.-_']*\s[a-zA-Z,.-_']*", ErrorMessage ="You must have people to put into the teams!")]
        [DisplayName("MemberNames")]
        public string MemberNames {get; set;}

        [Required]
        [DisplayName("TeamSize")]
        [Range(2,10)] 
        public int TeamSize {get; set;}

        public int TeamCount {get; set;}
        
        static readonly string textFile = @"Data\animals.txt";
        public TeamsVM()
        {
            TeamNames = "";
            if (File.Exists(textFile))
            {
                TeamNames = File.ReadAllText(textFile);
            }
            
            MemberNames = "";
            TeamSize = 2;
        }

        /*
            1. Test to make sure that the member names actually
                get split up so that they can be used later.
        */

        public List<string> splitMemberNames()
        {
            var members = new List<string>();
            var temp = MemberNames.Split("\n");
            foreach(var i in temp)
            {
                members.Add(i);
            }
            return members;
        }

        /*Could make two tests here.
            1. Test to make sure the list gets randomized.
            2. Makes sure a list of one still gets used.
                -- I know this is a pointless thing to test for,
                    but for the sake of code coverage it would be
                    ideal. This check is mainly to reduce the work
                    the computer has to actually do, and not for an
                    error trapping behavior.
        */
        public List<string> randomizeMembersNames(List<string> members)
        {
            if(members.Count() == 1)
            {
                return members;
            }
            else
            {
                var random = new Random();
                var temp = members.OrderBy(e => random.Next()).ToList();
                members = temp;
                return members;
            }
        }

        /* [Tests]
            1.  randomMembers list comes in with an even number of names
            2.  randomMembers comes in with an odd number of names
                1. Both cases result in the correct number of teams
                    - No matter how big a team is suppposed to be,
                        leftover names get assigned to the last team.
                        This tests the if statement.
            3.  No team is bigger than the sizeOfTeams desired.
            4.  If the number of names that comes in is smaller
                than the desired team size, it will just make one team.
        */
        public List<List<string>> makeRandomTeams(int sizeOfTeams, List<string> randomMembers)
        {
            var team = new List<string>();
            var teams = new List<List<string>>();
            var numberOfTeams = randomMembers.Count()/sizeOfTeams;
            if(sizeOfTeams > randomMembers.Count())
            {
                foreach(var member in randomMembers)
                {
                    team.Add(member);
                }
                teams.Add(team);
            }
            else
            {
                for(var i = 0; i < numberOfTeams; i++)
                {
                    for(var j = 0; j < sizeOfTeams; j++)
                    {
                        team.Add(randomMembers.First());
                        randomMembers.RemoveAt(0);
                    }
                    teams.Add(team);
                    team = new();
                    if(randomMembers.Count() < sizeOfTeams && randomMembers.Count() > 0)
                    {
                        teams.Add(randomMembers);
                    }
                }
            }
            TeamCount = teams.Count();
            return teams;
        }
    }
}