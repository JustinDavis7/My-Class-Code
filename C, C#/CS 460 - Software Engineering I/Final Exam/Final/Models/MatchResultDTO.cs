using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public partial class MatchResultDTO
    {
        
        public int Id { get; set; }
        public DateTime FullTime { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        public void FromMatchResult(MatchResult mr)
        {
            Id = mr.Id;
            FullTime = mr.FullTime;
            HomeTeamId = mr.HomeTeamId;
            AwayTeamId = mr.AwayTeamId;
            HomeTeamGoals = mr.HomeTeamGoals;
            AwayTeamGoals = mr.AwayTeamGoals;
        }
        public MatchResult ToMatchResult()
        {
            MatchResult result = new MatchResult
            {
                Id            = Id,
                FullTime      = FullTime,
                HomeTeamId    = HomeTeamId,
                AwayTeamId    = AwayTeamId,
                HomeTeamGoals = HomeTeamGoals,
                AwayTeamGoals = AwayTeamGoals
            };
            return result;
        }
    }
}
