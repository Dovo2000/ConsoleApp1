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
            return 2 * Math.PI * Math.Sqrt((Math.Pow(radioH, 2) + Math.Pow(radioV, 2)) / 2); // https://www.universoformulas.com/matematicas/geometria/perimetro-elipse/
        }
    }
}
