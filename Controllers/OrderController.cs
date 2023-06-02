using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VerstaTask.Models.Dtos;
using VerstaTask.Services.Interfaces;

namespace VerstaTask.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OrderIndex()
        {
			var orderDtosList = new List<OrderDto>();
			var response = await _orderService.GetOrdersAsync();
			if (response is not null && response.IsSuccess)
			{
				orderDtosList = JsonConvert.DeserializeObject<List<OrderDto>>(response.Result.ToString());
			}
			return View(orderDtosList);
		}

		public async Task<IActionResult> OrderCreate()
		{
			return View();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> OrderCreate(OrderDto orderDto)
		{
			if (ModelState.IsValid)
			{
				var response = await _orderService.CreateOrderAsync(orderDto);
				if (response is not null && response.IsSuccess)
				{
					return RedirectToAction(nameof(OrderIndex));
				}
			}
			return View(orderDto);
		}

		public async Task<IActionResult> OrderInfo(int orderId)
		{
			var response = await _orderService.GetOrderByIdAsync(orderId);
			if (response is not null && response.IsSuccess)
			{
				var departmentDto = JsonConvert.DeserializeObject<OrderDto>(response.Result.ToString());
				return View(departmentDto);
			}
			return NotFound();
		}
	}
}
