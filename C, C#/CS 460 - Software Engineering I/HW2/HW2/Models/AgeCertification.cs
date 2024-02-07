using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models
{
    [Table("AgeCertification")]
    public partial class AgeCertification
    {
        public AgeCertification()
        {
            Shows = new HashSet<Show>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(20)]
        public string CertificationIdentifier { get; set; } = null!;

        [InverseProperty("AgeCertification")]
        public virtual ICollection<Show> Shows { get; set; }
    }
}
