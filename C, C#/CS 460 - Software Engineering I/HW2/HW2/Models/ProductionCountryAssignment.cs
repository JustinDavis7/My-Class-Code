using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models
{
    public partial class ProductionCountryAssignment
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ShowID")]
        public int ShowId { get; set; }
        [Column("ProductionCountryID")]
        public int ProductionCountryId { get; set; }

        [ForeignKey("ProductionCountryId")]
        [InverseProperty("ProductionCountryAssignments")]
        public virtual ProductionCountry ProductionCountry { get; set; } = null!;
        [ForeignKey("ShowId")]
        [InverseProperty("ProductionCountryAssignments")]
        public virtual Show Show { get; set; } = null!;
    }
}
