using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ChartJsMvcCore.Entity
{
    [Table("tblProduct")]
    public partial class TblProduct
    {
        [Key]
        public int Id { get; set; }
        [Column("ProductSUN")]
        [StringLength(50)]
        public string ProductSun { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        public int? Qty { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? WholeSalePrice { get; set; }
        public int? OnHandQty { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
    }
}
