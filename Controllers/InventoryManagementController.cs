using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    /// <summary>
    /// Home HTTP Controller
    /// </summary>
    public class InventoryManagementController : Controller
    {

        // 
        // GET: /InventoryManagement/
        public IActionResult Index()
        {
            return View();
        }
    }
}