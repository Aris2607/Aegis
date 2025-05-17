using AegisTest.Data.Interfaces;
using AegisTest.Dtos;

namespace AegisTest.Data.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<OrderReportDto> _orders = new List<OrderReportDto>
        {
            new() {
                OrderId = 1,
                CustomerName = "Eru",
                Email = "eru2212@gmail.com",
                ProductName = "Logitech Wireless Mouse",
                Price = 150000m,
                Quantity = 2,
                OrderDate = new DateTime(2024, 5, 1)
            },
            new() {
                OrderId = 2,
                CustomerName = "Lina",
                Email = "lina@gmail.com",
                ProductName = "Kingston 16GB USB Flash Drive",
                Price = 90000m,
                Quantity = 1,
                OrderDate = new DateTime(2024, 5, 2)
            },
            new()
            {
                OrderId = 3,
                CustomerName = "Kai",
                Email = "kai@gmail.com",
                ProductName = "TP-Link WiFi Router",
                Price = 250000m,
                Quantity = 1,
                OrderDate = new DateTime(2024, 5, 3)
            },
            new()
            {
                OrderId = 4,
                CustomerName = "Mira",
                Email = "mira@gmail.com",
                ProductName = "Logitech K120 Keyboard",
                Price = 120000m,
                Quantity = 2,
                OrderDate = new DateTime(2024, 5, 4)
            },
            new()
            {
                OrderId = 5,
                CustomerName = "Noah",
                Email = "noah@gmail.com",
                ProductName = "WD 1TB External HDD",
                Price = 750000m,
                Quantity = 1,
                OrderDate = new DateTime(2024, 5, 5)
            },
            new() {
                OrderId = 6,
                CustomerName = "Sara",
                Email = "sara@gmail.com",
                ProductName = "TP-Link USB WiFi Adapter",
                Price = 80000m,
                Quantity = 3,
                OrderDate = new DateTime(2024, 5, 6)
            },
            new()
            {
                OrderId = 7,
                CustomerName = "Tom",
                Email = "tom@gmail.com",
                ProductName = "Acer 24\" LED Monitor",
                Price = 1800000m,
                Quantity = 1,
                OrderDate = new DateTime(2024, 5, 7)
            },
            new()
            {
                OrderId = 8,
                CustomerName = "Anna",
                Email = "anna@gmail.com",
                ProductName = "Rexus Gaming Mousepad",
                Price = 50000m,
                Quantity = 2,
                OrderDate = new DateTime(2024, 5, 8)
            },
            new()
            {
                OrderId = 9,
                CustomerName = "Leo",
                Email = "leo@gmail.com",
                ProductName = "Sandisk 32GB MicroSD",
                Price = 70000m,
                Quantity = 2,
                OrderDate = new DateTime(2024, 5, 9)
            },
            new()
            {
                OrderId = 10,
                CustomerName = "Maya",
                Email = "maya@gmail.com",
                ProductName = "TP-Link 8-Port Switch",
                Price = 230000m,
                Quantity = 1,
                OrderDate = new DateTime(2024, 5, 10)
            }
        };
        public Task<IEnumerable<OrderReportDto>> GetOrdersAsync()
        {
            return Task.FromResult<IEnumerable<OrderReportDto>>(_orders);
        }
    }
}