
using System.ComponentModel.DataAnnotations;

namespace OrderManagerMvc.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress, StringLength(200)]
        public string? Email { get; set; }

        [Phone, StringLength(40)]
        public string? Phone { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
