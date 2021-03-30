using Microsoft.Extensions.Logging;
using MindBoxCode.Abstractions;
using MindBoxCode.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindBoxCode.Infrastructure
{
    public class OrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderStorage _orderStorage;
        private readonly IFiguresStorage _figuresStorage;

        public OrderService(ILogger<OrderService> logger, IOrderStorage orderStorage, IFiguresStorage figuresStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
            _figuresStorage = figuresStorage;
        }
        public async Task<double> CreateOrderAndSave(Cart cart)
        {
            if (!await CheckIfListAvailable(cart.Positions))
            {
                _logger.LogError("Not all Figures are available");
                return -1;
            }

            Order order = new()
            {
                Positions = GetPositions(cart).ToList()
            };
            await ReserveAll(cart.Positions);
            var result = await SaveOrder(order);

            return result;
        }

        private static IEnumerable<Figure> GetPositions(Cart cart)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            return cart.Positions.Select(p => FigureFactory.Create(p));
        }

        private async Task<double> SaveOrder(Order order)
            => await _orderStorage.Save(order);

        private async Task ReserveAll(IEnumerable<Position> positions)
            => await _figuresStorage.ReserveList(positions.Select(position => (position.Type, position.Count)).ToList());

        private async Task<bool> CheckIfListAvailable(IEnumerable<Position> positions)
            => await _figuresStorage.CheckIfListAvailable(positions.Select(position => (position.Type, position.Count)).ToList());
    }
}
