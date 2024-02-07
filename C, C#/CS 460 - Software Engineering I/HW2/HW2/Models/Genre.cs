using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models
{
    [Table("Genre")]
    public partial class Genre
    {
        public Genre()
        {
            GenreAssignments = new HashSet<GenreAssignment>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(32)]
        public string GenreString { get; set; } = null!;

        [InverseProperty("Genre")]
        public virtual ICollection<GenreAssignment> GenreAssignments { get; set; }
    }
}
