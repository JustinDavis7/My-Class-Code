using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Table("Position")]
    public partial class Position
    {
        public Position()
        {
            Players = new HashSet<Player>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty("Position")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
