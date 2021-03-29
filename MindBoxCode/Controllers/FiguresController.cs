using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MindBoxCode.Domain;
using MindBoxCode.Infrastructure;
using System;
using System.Threading.Tasks;

namespace MindBoxCode.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FiguresController : ControllerBase
	{
		private readonly ILogger<FiguresController> _logger;
		private readonly OrderService _orderService;

		public FiguresController(ILogger<FiguresController> logger, OrderService orderService)
		{
			_logger = logger;
			_orderService = orderService;
		}

		// хотим оформить заказ и получить в ответе его стоимость
		[HttpPost]
		public async Task<ActionResult> Order(Cart cart)
		{
			try
			{
				var result = await _orderService.CreateOrderAndSave(cart);
				
				if (result == -1)
					return new BadRequestResult();

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Exception was thrown!");
				return new BadRequestResult();
			}
		}

		
		
	}
}
