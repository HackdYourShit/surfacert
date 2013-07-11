using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MVCSurfaceRTStore.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual UserProfile User { get; set; }
    }

    [Table("OrderedProduct")]
    public class OrderedProduct
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderedProductId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual UserProfile User { get; set; }
        public bool Paid { get; set; }
    }
}