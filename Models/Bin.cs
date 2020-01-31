using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    /// <summary>
    /// A Bin represents a warehouse section. Each Bin has a unique name
    /// and contains a set of Inventory entries
    /// </summary>
    public class Bin
    {
        [Key]
        [Display(Name = "Bin ID")]
        public int BinID { get; set; }
        [Required]
        public string BinName { get; set; }

        // Reference field for Inventory objects in the Bin
        public virtual IList<Inventory> Inventory { get; set; }
    }
}
