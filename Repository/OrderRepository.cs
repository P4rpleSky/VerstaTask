using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VerstaTask.DbContexts;
using VerstaTask.Models;
using VerstaTask.Models.Dtos;

namespace VerstaTask.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly VerstaDbContext _db;

        public OrderRepository(VerstaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

		public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
		{
			var order = _mapper.Map<OrderDto, Order>(orderDto);
            _db.Orders.Add(order);

            await _db.SaveChangesAsync();
            return _mapper.Map<Order, OrderDto>(order);
		}

		public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _db.Orders.FirstAsync(x => x.Id == orderId);
            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync()
        {
            var orders = await _db.Orders.ToListAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
