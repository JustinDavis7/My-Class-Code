using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Table("MatchResult")]
    public partial class MatchResult
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FullTime { get; set; }
        [Column("HomeTeamID")]
        public int HomeTeamId { get; set; }
        [Column("AwayTeamID")]
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        [ForeignKey("AwayTeamId")]
        [InverseProperty("MatchResultAwayTeams")]
        public virtual Country AwayTeam { get; set; } = null!;
        [ForeignKey("HomeTeamId")]
        [InverseProperty("MatchResultHomeTeams")]
        public virtual Country HomeTeam { get; set; } = null!;
    }
}
