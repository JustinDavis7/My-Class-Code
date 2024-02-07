using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW6.Models
{
    [Table("STask")]
    public partial class Stask
    {
        public Stask()
        {
            StaskCompleteds = new HashSet<StaskCompleted>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(256)]
        public string Todo { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        public int Interval { get; set; }
        [Column("SubjectID")]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        [InverseProperty("Stasks")]
        public virtual Subject Subject { get; set; } = null!;
        [InverseProperty("Stask")]
        public virtual ICollection<StaskCompleted> StaskCompleteds { get; set; }
    }
}
