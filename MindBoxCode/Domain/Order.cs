using MindBoxCode.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindBoxCode.Domain
{
	public class Order
	{
		public List<Figure> Positions { get; set; }

		public decimal GetTotal() =>
			Positions.Select(p => p switch
            {
                Triangle => (decimal)p.GetArea() * 1.2m,
                Circle => (decimal)p.GetArea() * 0.9m,
                Square => (decimal)p.GetArea(),
                _ => throw new NotImplementedException()
            }).Sum();
	}
}
