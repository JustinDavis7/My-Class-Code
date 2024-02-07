using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW4.Models
{
    [Table("Person")]
    public partial class Person
    {
        public Person()
        {
            CompletedTasks = new HashSet<CompletedTask>();
            ToDoItems = new HashSet<ToDoItem>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50),Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50),Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = null!;

        [InverseProperty("Person")]
        public virtual ICollection<CompletedTask> CompletedTasks { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
