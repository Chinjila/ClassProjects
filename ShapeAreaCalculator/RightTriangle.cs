using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculator
{
    internal class RightTriangle: Triangle
    {
        public RightTriangle(int side, int height, int triBase, string name) : base(side, height, triBase, name)
        {
            name = "Right Triangle";
            
        }
 
    }
}
