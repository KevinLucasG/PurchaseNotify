using Microsoft.AspNetCore.Mvc;
using PurchaseNotify.Data;
using PurchaseNotify.Models;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;
using PurchaseNotify.Services;
using System.Text.Json;

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

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(PurchaseDTO obj)
        {
           
            

            var rabbitMqService = new RabbitMqService("localhost", "Purchase");

            var message = JsonSerializer.Serialize(obj); 
            var messageBytes = Encoding.UTF8.GetBytes(message);

            rabbitMqService.SendMessage(messageBytes);

            return RedirectToAction("Confirmation");
        }


    }
}
