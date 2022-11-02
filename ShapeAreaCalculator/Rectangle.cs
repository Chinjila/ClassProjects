using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculator
{
    internal class Rectangle : Square
    {
        int height;
        int width;
        public Rectangle(int height, int width): base(height)
        {
            this.width = width; 
        }

        public Double Area(int h, int w)
        {
            return h * w;
        }
    }
}
