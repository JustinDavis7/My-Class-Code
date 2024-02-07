using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models
{
    [Table("Credit")]
    public partial class Credit
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ShowID")]
        public int ShowId { get; set; }
        [Column("PersonID")]
        public int PersonId { get; set; }
        [Column("RoleID")]
        public int RoleId { get; set; }
        [StringLength(128)]
        public string? CharacterName { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("Credits")]
        public virtual Person Person { get; set; } = null!;
        [ForeignKey("RoleId")]
        [InverseProperty("Credits")]
        public virtual Role Role { get; set; } = null!;
        [ForeignKey("ShowId")]
        [InverseProperty("Credits")]
        public virtual Show Show { get; set; } = null!;
    }
}
