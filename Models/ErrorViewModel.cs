using System;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Error View Model 
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
