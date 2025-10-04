
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagerMvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(160)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(40)]
        public string Sku { get; set; } = string.Empty;

        [Range(0, 1_000_000), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
