using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            MatchResultAwayTeams = new HashSet<MatchResult>();
            MatchResultHomeTeams = new HashSet<MatchResult>();
            Players = new HashSet<Player>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FullName { get; set; } = null!;
        [StringLength(8)]
        public string Abbreviation { get; set; } = null!;
        [Column("FlagImageURL")]
        [StringLength(20)]
        public string FlagImageUrl { get; set; } = null!;

        [InverseProperty("AwayTeam")]
        public virtual ICollection<MatchResult> MatchResultAwayTeams { get; set; }
        [InverseProperty("HomeTeam")]
        public virtual ICollection<MatchResult> MatchResultHomeTeams { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
