using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class Rombo : Poligono
    {
        double diagonalMayor;
        double diagonalMenor;

        public Rombo(double diagonalMayor, double diagonalMenor) : base(4)
        {
            this.diagonalMayor = diagonalMayor;
            this.diagonalMenor = diagonalMenor;
        }

        public override double Area()
        {
            return (diagonalMayor * diagonalMenor) / 2;
        }

        public override double Perimetro()
        {
            return 2 * Math.Sqrt(Math.Pow(diagonalMayor, 2) + Math.Pow(diagonalMenor, 2));
        }
    }
}
