namespace AegisTest.Dtos
{
    public class OrderReportDto
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
        public DateTime OrderDate { get; set; }
    }
}
