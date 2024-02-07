using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models
{
    [Table("ProductionCountry")]
    public partial class ProductionCountry
    {
        public ProductionCountry()
        {
            ProductionCountryAssignments = new HashSet<ProductionCountryAssignment>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(64)]
        public string CountryIdentifier { get; set; } = null!;

        [InverseProperty("ProductionCountry")]
        public virtual ICollection<ProductionCountryAssignment> ProductionCountryAssignments { get; set; }
    }
}
