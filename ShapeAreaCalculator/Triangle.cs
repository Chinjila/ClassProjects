using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculator
{
    internal class Triangle : ShapeBase
    {
        public string name = "Triangle";
        public int height;
        public int triBase;
        public Triangle(int side, int height, int triBase, string name): base(side)
        {
           this.height  = height;
           this.triBase = triBase;

        }

        public Double Area(int triBase, int height)
        {
            Double area = (triBase * height)/2;
            return area;
        }
    }
}
