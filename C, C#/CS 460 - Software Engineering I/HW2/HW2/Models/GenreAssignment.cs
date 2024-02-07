using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models
{
    [Table("GenreAssignment")]
    public partial class GenreAssignment
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ShowID")]
        public int ShowId { get; set; }
        [Column("GenreID")]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        [InverseProperty("GenreAssignments")]
        public virtual Genre Genre { get; set; } = null!;
        [ForeignKey("ShowId")]
        [InverseProperty("GenreAssignments")]
        public virtual Show Show { get; set; } = null!;
    }
}
