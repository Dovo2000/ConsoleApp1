using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class Cuadrado : Rectangulo
    {
        double lado;

        public Cuadrado(double longitudLado) : base(longitudLado, longitudLado){ }
    }
}
