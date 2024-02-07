using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW4.Models
{
    [Table("ItemTask")]
    public partial class ItemTask
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50),Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [StringLength(500),Required(AllowEmptyStrings = false)]
        public string Notes { get; set; } = null!;
        public bool Complete { get; set; }
        public int Frequency { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FirstCompletion { get; set; }
        [Column("ItemID")]
        public int? ItemId { get; set; }
        [Column("CompletedID")]
        public int? CompletedId { get; set; }

        [ForeignKey("CompletedId")]
        [InverseProperty("ItemTasks")]
        public virtual CompletedTask? Completed { get; set; }
        [ForeignKey("ItemId")]
        [InverseProperty("ItemTasks")]
        public virtual ToDoItem? Item { get; set; }
    }
}
