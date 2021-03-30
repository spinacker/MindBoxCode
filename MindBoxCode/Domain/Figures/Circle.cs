using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindBoxCode.Abstractions
{
	public class Circle : Figure
	{
		public Circle(float radius)
		{
			SideA = radius;
			Validate();
		}

		public override void Validate()
		{
			if (SideA < 0)
				throw new InvalidOperationException("Circle restrictions not met");
		}

		public override double GetArea() => Math.PI * SideA * SideA;
	}
}
