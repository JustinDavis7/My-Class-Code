using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW4.Models
{
    [Table("ToDoItem")]
    public partial class ToDoItem
    {
        public ToDoItem()
        {
            ItemTasks = new HashSet<ItemTask>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50),Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = null!;
        [StringLength(500),Required(AllowEmptyStrings = false)]
        public string Description { get; set; } = null!;
        [Column("PersonID")]
        public int? PersonId { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("ToDoItems")]
        public virtual Person? Person { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemTask> ItemTasks { get; set; }
    }
}
