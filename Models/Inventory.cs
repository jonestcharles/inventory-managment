using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Inventory model, each Inventory entry corresponds to a Bin and a Product, and must have
    /// positive, non-zero quantity. Represents warehouse inventory by product and location.
    /// </summary>
    public class Inventory
    {
        [Key]
        [Display(Name = "Inventory ID")]
        public int InventoryID { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value larger than 0")]
        public int QTY { get; set; }

        [Required]
        public int BinID { get; set; }
        // Reference field for the corresponding Bin
        public virtual Bin Bin { get; set; }

        [Required]
        public int ProductID { get; set; }
        // Reference field for the corresponding Product
        public virtual Product Product { get; set; }

        // Computed Bin + Product ID for validation
        //public string UniqInventory {
        //    set {
        //        this.UniqInventory = ProductID.ToString() + BinID.ToString();
        //    }

        //    get {
        //        return this.UniqInventory;
        //    }
        //}
    }
}
