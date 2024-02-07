using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Table("Club")]
    public partial class Club
    {
        public Club()
        {
            Players = new HashSet<Player>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty("ClubTeam")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
