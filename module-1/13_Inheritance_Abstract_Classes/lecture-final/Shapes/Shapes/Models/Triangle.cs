using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    class Triangle : Shape2D
    {
        private int triangleBase;
        private int height;

        public Triangle(ConsoleColor color, bool isFilled, int triangleBase, int height) : base(color, isFilled)
        {
            this.triangleBase = triangleBase;
            this.height = height;
        }

        public override int Area
        {
            get
            {
                return (int)(0.5 * triangleBase * height);
            }
        }

        public override int Perimeter
        {
            get
            {
                return 100;
            }
        }

        public override void Draw()
        {
            Console.WriteLine("This is a triangle");
        }
    }
}
