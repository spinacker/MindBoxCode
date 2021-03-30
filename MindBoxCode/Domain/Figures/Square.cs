using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindBoxCode.Abstractions
{
	public class Square : Figure
	{
		public Square(float sideA, float sideB)
		{
			SideA = sideA;
			SideB = sideB;
			Validate();
		}

		public override void Validate()
		{
			if (SideA < 0)
				throw new InvalidOperationException("Square restrictions not met");

			if (SideA != SideB)
				throw new InvalidOperationException("Square restrictions not met");
		}

		public override double GetArea() => SideA * SideA;
	}
}
