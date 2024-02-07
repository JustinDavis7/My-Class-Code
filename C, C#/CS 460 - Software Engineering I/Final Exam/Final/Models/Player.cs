using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Table("Player")]
    public partial class Player
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FullName { get; set; } = null!;
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Column("PositionID")]
        public int PositionId { get; set; }
        [StringLength(10)]
        public string? Weight { get; set; }
        [StringLength(10)]
        public string? Height { get; set; }
        public int? Age { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [Column("ClubTeamID")]
        public int? ClubTeamId { get; set; }

        [ForeignKey("ClubTeamId")]
        [InverseProperty("Players")]
        public virtual Club? ClubTeam { get; set; }
        [ForeignKey("CountryId")]
        [InverseProperty("Players")]
        public virtual Country Country { get; set; } = null!;
        [ForeignKey("PositionId")]
        [InverseProperty("Players")]
        public virtual Position Position { get; set; } = null!;
    }
}
