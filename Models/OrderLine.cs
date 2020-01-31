using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    /// <summary>
    /// OrderLines are related to an Order and specify which Product was ordered, and how many.
    /// Orders can have many OrderLines
    /// </summary>
    [Owned]
    public class OrderLine
    {
        [Key]
        [Display(Name = "Order Line ID")]
        public int OrderLineID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value larger than 1")]
        public int QTY { get; set; }

        // Reference field for corresponding Order
        public virtual Order Order { get; set; }
        // Reference field for corresponding Product
        public virtual Product Product { get; set; }
    }
}
