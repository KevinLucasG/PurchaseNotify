using Microsoft.AspNetCore.Mvc;
using PurchaseNotify.Data;
using PurchaseNotify.Models;

namespace PurchaseNotify.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly ApplicationDbContext _db;
                         
        public PurchaseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
