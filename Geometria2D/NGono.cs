using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class NGono : Poligono // asumiendo que son regulares
    {
        double lado; 

        public NGono(int numeroLados, double longitudLado) : base(numeroLados)
        {
            lado = longitudLado;
        }

        private double CalcApotema()
        {
            double anguloInterior = 360 / (2 * numLados);

            return lado / (2 * Math.Tan((Math.PI / 180) * anguloInterior));
        }

        public override double Area()
        {
            return (Perimetro() * CalcApotema()) / 2;
        }

        public override double Perimetro()
        {
            return lado * numLados;
        }
    }
}
