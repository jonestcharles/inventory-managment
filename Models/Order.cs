using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Orders represent an order palced by a customer for one or more Products
    /// </summary>
    public class Order
    {
        [Key]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }
        [Required]
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Ordered")]
        public DateTime DateOrdered { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }

        // Reference field for OrderLine entries for this Order
        public virtual IList<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Initializer for creating a default Order with a new OrderLine collection.
        /// Used for creating a new Order entry
        /// </summary>
        /// <returns>order: a new order instance with default values</returns>
        public static Order Create() {
            var order = new Order();
            order.OrderNumber = "";
            order.CustomerName = "";
            order.CustomerAddress = "";
            order.DateOrdered = DateTime.Today;

            var lines = new List<OrderLine>();
            lines.Add(new OrderLine() { Order = order, ProductID = 1, QTY = 1});

            order.OrderLines = lines;
            return order;
        }
    }
}
