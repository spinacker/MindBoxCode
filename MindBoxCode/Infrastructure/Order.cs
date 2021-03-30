using MindBoxCode.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindBoxCode.Infrastructure
{
    public class Order
    {
        public List<Figure> Positions { get; set; }

        /// TODO: Проверить необходимость данного метода и правильность расчета
        /// нет необходимости использовать decimal
		public decimal GetTotalAreas()
        => Positions.Select(p => p switch
                  {
                      Triangle => Convert.ToDecimal(p.GetArea()) * 1.2m, // TODO: что такое 1.2?
                      Circle => Convert.ToDecimal(p.GetArea()) * 0.9m,   // TODO: что такое 0.9?
                      { } => Convert.ToDecimal(p.GetArea()),
                  }).Sum();
    }
}
