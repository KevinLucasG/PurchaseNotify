using System.ComponentModel.DataAnnotations;

namespace PurchaseNotify.Models
{
    public class Purchase
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public DateTime PurchaseDateTime { get; set; } = DateTime.Now;
    }
}
