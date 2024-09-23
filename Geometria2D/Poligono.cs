using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal abstract class Poligono : Figura2D
    {
        protected int numLados;

        public Poligono(int numeroLados) 
        {
            numLados = numeroLados;
        }
    }
}
