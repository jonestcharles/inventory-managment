using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Product represents a unique product type by SKU that can be stocked in the warehouse
    /// </summary>
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Required]
        public string SKU { get; set; }
        [Display(Name = "Product Description")]
        [Required]
        public string ProductDescription { get; set; }

        // Reference field for Inventory entries for this Product
        public virtual IList<Inventory> Inventory {get; set;}
    }
}
