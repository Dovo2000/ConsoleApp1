using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class Rectangulo : Poligono
    {
        double ladoBase;
        double ladoAltura;

        public Rectangulo(double ladoBase, double ladoAltura) : base(4)
        {
            this.ladoBase = ladoBase;
            this.ladoAltura = ladoAltura;
        }

        public override double Area()
        {
            return ladoBase * ladoAltura;
        }

        public override double Perimetro()
        {
            return 2 * ladoBase + 2 * ladoAltura;
        }
    }
}
