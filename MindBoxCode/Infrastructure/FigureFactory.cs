using MindBoxCode.Abstractions;
using MindBoxCode.Domain;

namespace MindBoxCode.Infrastructure
{
    public static class FigureFactory
    {
        public static Figure Create(string Type, float SideA, float SideB, float SideC)
            => Type switch
            {
                "Circle" => new Circle(SideA),
                "Triangle" => new Triangle(SideA, SideB, SideC),
                "Square" => new Square(SideA, SideB),
                _ => throw new System.NotImplementedException()
            };

        public static Figure Create(Position position)
             => Create(position.Type, position.SideA, position.SideB, position.SideC);
    }
}
