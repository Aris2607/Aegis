using AegisTest.Dtos;

namespace AegisTest.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderReportDto>> GetOrdersAsync();
    }
}