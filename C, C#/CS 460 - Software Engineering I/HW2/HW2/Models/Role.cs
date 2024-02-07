using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models
{
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Credits = new HashSet<Credit>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(32)]
        public string RoleName { get; set; } = null!;

        [InverseProperty("Role")]
        public virtual ICollection<Credit> Credits { get; set; }
    }
}
