
using OrderManagerMvc.Models;

namespace OrderManagerMvc.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Customers.Any() || db.Products.Any()) return;

            var customers = new[] {
                new Customer { Name = "Acme Industries", Email = "buyer@acme.com", Phone = "403-555-0100", Address="100 Main St" },
                new Customer { Name = "Globex Corp", Email = "purchasing@globex.com", Phone = "403-555-0101", Address="200 1st Ave" }
            };
            db.Customers.AddRange(customers);

            var products = new[] {
                new Product { Name="USB-C Cable 1m", Sku="CAB-USB-C-1M", UnitPrice=12.50m },
                new Product { Name="Wireless Mouse", Sku="MOU-WLS-001", UnitPrice=29.99m },
                new Product { Name="27in Monitor", Sku="MON-27-4K", UnitPrice=399.00m }
            };
            db.Products.AddRange(products);

            db.SaveChanges();

            // Seed one sample order
            var order = new Order { CustomerId = customers[0].Id, OrderDate = DateTime.UtcNow, Status="Submitted" };
            db.Orders.Add(order);
            db.SaveChanges();

            var items = new[] {
                new OrderItem { OrderId = order.Id, ProductId = products[0].Id, Quantity = 3, UnitPrice = products[0].UnitPrice },
                new OrderItem { OrderId = order.Id, ProductId = products[1].Id, Quantity = 1, UnitPrice = products[1].UnitPrice }
            };
            db.OrderItems.AddRange(items);
            db.SaveChanges();
        }
    }
}
