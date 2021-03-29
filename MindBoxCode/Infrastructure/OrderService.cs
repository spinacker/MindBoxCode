using Microsoft.Extensions.Logging;
using MindBoxCode.Abstractions;
using MindBoxCode.Controllers;
using MindBoxCode.DAL.Abstractions;
using MindBoxCode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindBoxCode.Infrastructure
{
    public class OrderService
    {
        private readonly ILogger<FiguresController> _logger;
        private readonly IOrderStorage _orderStorage;
        private readonly IFiguresStorage _figuresStorage;

        public OrderService(ILogger<FiguresController> logger, IOrderStorage orderStorage, IFiguresStorage figuresStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
            _figuresStorage = figuresStorage;
        }
        public async Task<decimal> CreateOrderAndSave(Cart cart)
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

        private async Task<decimal> SaveOrder(Order order)
            => await _orderStorage.Save(order);

        //private async Task ReserveAll(IEnumerable<Position> positions)
        //    => await _figuresStorage.ReserveList(positions.Select(x => Convert(x)).ToList());


        //private async Task<bool> CheckIfListAvailable(IEnumerable<Position> positions)
        //    => await _figuresStorage.CheckIfListAvailable(positions.Select(x => Convert(x)).ToList());

        private async Task ReserveAll(IEnumerable<Position> positions)
            => await _figuresStorage.ReserveList(positions.Select(position => (position.Type, position.Count)).ToList());

        private async Task<bool> CheckIfListAvailable(IEnumerable<Position> positions)
            => await _figuresStorage.CheckIfListAvailable(positions.Select(position => (position.Type, position.Count)).ToList());


        private static (string type, int count) Convert(Position position)
            => (position.Type, position.Count);
        
    }
}
