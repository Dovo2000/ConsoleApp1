using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class Circulo : Elipse
    {
        public Circulo(double radio) : base(radio, radio){ }

        public override double Perimetro()
        {
            return 2 * Math.PI * radioH;
        }
    }
}
