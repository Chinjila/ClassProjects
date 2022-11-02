using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculator
{
    internal class ShapeBase
    {
        int sides;

        public ShapeBase(int side)
        {
            this.sides = side;

        }

        public virtual Double Area(int side)
        {
            return Math.Pow(side, 2);
        }
            
 
    }
}
