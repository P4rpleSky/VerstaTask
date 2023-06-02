using VerstaTask.Models.Dtos;

namespace VerstaTask.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseDto> GetOrdersAsync();
        Task<ResponseDto> GetOrderByIdAsync(int orderId);
        Task<ResponseDto> CreateOrderAsync(OrderDto orderDto);
    }
}
