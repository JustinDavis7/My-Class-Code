using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW4.Models
{
    [Table("CompletedTask")]
    public partial class CompletedTask
    {
        public CompletedTask()
        {
            ItemTasks = new HashSet<ItemTask>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50),Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime CompletionDate { get; set; }
        [Column("PersonID")]
        public int? PersonId { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("CompletedTasks")]
        public virtual Person? Person { get; set; }
        [InverseProperty("Completed")]
        public virtual ICollection<ItemTask> ItemTasks { get; set; }
    }
}
