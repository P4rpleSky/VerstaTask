using VerstaTask.Models.Dtos;

namespace VerstaTask.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
    }
}
