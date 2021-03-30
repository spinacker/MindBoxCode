using System;

namespace MindBoxCode.Abstractions
{
	public class Triangle : Figure
	{
		public Triangle(float sideA, float sideB, float sideC)
		{
			SideA = sideA;
			SideB = sideB;
			SideC = sideC;
			Validate();
		}

		static bool CheckTriangleInequality(float a, float b, float c) => a < b + c;

		public override void Validate()
		{
			if (CheckTriangleInequality(SideA, SideB, SideC)
				&& CheckTriangleInequality(SideB, SideA, SideC)
				&& CheckTriangleInequality(SideC, SideB, SideA))
				return;
			throw new InvalidOperationException("Triangle restrictions not met");
		}

		public override double GetArea()
		{
			var p = (SideA + SideB + SideC) / 2;
			return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
		}

	}
}
