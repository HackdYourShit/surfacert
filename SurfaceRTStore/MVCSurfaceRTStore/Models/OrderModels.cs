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

    public class OrderModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "U kunt dit veld niet leeg laten.", MinimumLength = 1)]
        [RegularExpression("([0-9]+)", ErrorMessage = "U heeft geen geld getal ingevuld.")]
        [Display(Name = "Aantal van het model: Surface RT 32GB")]
        public string ModelEen { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U kunt dit veld niet leeg laten.", MinimumLength = 1)]
        [RegularExpression("([0-9]+)", ErrorMessage = "U heeft geen geld getal ingevuld.")]
        [Display(Name = "Aantal van het model: Surface RT 32GB + Touch Cover Zwart")]
        public string ModelTwee { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U kunt dit veld niet leeg laten.", MinimumLength = 1)]
        [RegularExpression("([0-9]+)", ErrorMessage = "U heeft geen geld getal ingevuld.")]
        [Display(Name = "Aantal van het model: Surface RT 32GB + Touch Cover Cyaan")]
        public string ModelDrie { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U kunt dit veld niet leeg laten.", MinimumLength = 1)]
        [RegularExpression("([0-9]+)", ErrorMessage = "U heeft geen geld getal ingevuld.")]
        [Display(Name = "Aantal van het model: Surface RT 32GB + Touch Cover Wit")]
        public string ModelVier { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U kunt dit veld niet leeg laten.", MinimumLength = 1)]
        [RegularExpression("([0-9]+)", ErrorMessage = "U heeft geen geld getal ingevuld.")]
        [Display(Name = "Aantal van het model: Surface RT 32GB + Type Cover Zwart")]
        public string ModelVijf { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U kunt dit veld niet leeg laten.", MinimumLength = 1)]
        [RegularExpression("([0-9]+)", ErrorMessage = "U heeft geen geld getal ingevuld.")]
        [Display(Name = "Aantal van het accessoire: Surface VGA Adapter")]
        public string AccessoireEen { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U kunt dit veld niet leeg laten.", MinimumLength = 1)]
        [RegularExpression("([0-9]+)", ErrorMessage = "U heeft geen geld getal ingevuld.")]
        [Display(Name = "Aantal van het accessoire: Surface HD Digital AV-adapter")]
        public string AccessoireTwee { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U kunt dit veld niet leeg laten.", MinimumLength = 1)]
        [RegularExpression("([0-9]+)", ErrorMessage = "U heeft geen geld getal ingevuld.")]
        [Display(Name = "Aantal van het accessoire: Surface Voeding 24W")]
        public string AccessoireDrie { get; set; }
    }
}