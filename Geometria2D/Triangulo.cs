using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class Triangulo : Poligono
    {
        double lado1;
        double lado2;
        double lado3;

        public Triangulo(double lado1, double lado2, double lado3) : base(3)
        {
            this.lado1 = lado1;
            this.lado2 = lado2;
            this.lado3 = lado3;
        }

        public override double Area()
        {
            double semiperimetro = Perimetro() / 2;

            return Math.Sqrt(semiperimetro * (semiperimetro - lado1) * (semiperimetro - lado2) * (semiperimetro - lado3));
        }

        public override double Perimetro()
        {
            return lado1 + lado2 + lado3;
        }
    }
}
