using Microsoft.AspNetCore.Mvc;
using VerstaTask.Models.Dtos;
using VerstaTask.Repository;

namespace VerstaTask.Controllers
{
    [Route("api/orders")]
    public class OrderApiController : Controller
    {
        private ResponseDto _response;
        private readonly IOrderRepository _orderRepository;

        public OrderApiController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                var orders = await _orderRepository.GetOrdersAsync();
                _response.Result = orders;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.ToString());
            }
            return _response;
        }

        [HttpGet("orderId={orderId:int}")]
        public async Task<ResponseDto> Get(int orderId)
        {
            try
            {
                var order = await _orderRepository.GetOrderByIdAsync(orderId);
                _response.Result = order;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.ToString());
            }
            return _response;
        }

		[HttpPost]
		public async Task<ResponseDto> Post([FromBody] OrderDto orderDto)
		{
			try
			{
				var order = await _orderRepository.CreateOrderAsync(orderDto);
				_response.Result = order;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages.Add(ex.ToString());
			}
			return _response;
		}
	}
}
