using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class Elipse : Figura2D
    {
        protected double radioH;
        protected double radioV;

        public Elipse(double radioH, double radioV)
        {
            this.radioH = radioH;
            this.radioV = radioV;
        }

        public override double Area()
        {
            return Math.PI * radioH * radioV;
        }

        public override double Perimetro()
        {
            return Math.PI * (3.0 * (radioH + radioV) - Math.Sqrt((3.0 * radioH + radioV) * (radioH + 3.0 * radioV))); // https://www.universoformulas.com/matematicas/geometria/perimetro-elipse/
        }
    }
}
