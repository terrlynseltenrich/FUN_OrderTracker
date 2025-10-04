
using System.ComponentModel.DataAnnotations;

namespace OrderManagerMvc.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [StringLength(40)]
        public string Status { get; set; } = "Draft";

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        // Not mapped total; compute in queries/view models
        public decimal Total => Items.Sum(i => i.LineTotal);
    }
}
