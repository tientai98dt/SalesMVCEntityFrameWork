namespace SalesLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        public int ODId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(20)]
        public string Unit { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal Discount { get; set; }

        public decimal Tax { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
