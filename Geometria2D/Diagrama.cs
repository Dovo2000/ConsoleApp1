using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class Diagrama
    {
        enum eFormas2D
        {
            None = 0,
            Elipse,
            Circulo,
            Triangulo,
            Rectangulo,
            Cuadrado,
            Rombo,
            NGono,
            Count
        }

        List<Figura2D> figuras;
        int maxSize;

        public Diagrama(int maxSize)
        {
            Random random = new Random();
            figuras = new List<Figura2D>();

            this.maxSize = maxSize;

            while (maxSize > figuras.Count)
            {
                Figura2D nuevaFigura;
                eFormas2D tipoForma = (eFormas2D) random.Next(0, (int) eFormas2D.Count);

                Console.WriteLine(tipoForma.ToString());

                switch(tipoForma)
                {
                    case eFormas2D.None:
                        return;

                    case eFormas2D.Elipse:
                        double randomRadius1 = random.Next(0, 100);
                        double randomRadius2 = random.Next(0, 100);
                        nuevaFigura = new Elipse(randomRadius1, randomRadius2);
                        break;

                    case eFormas2D.Circulo:
                        double randomRadius = random.Next(0, 100);
                        nuevaFigura = new Circulo(randomRadius);
                        break;

                    case eFormas2D.Triangulo:
                        (double, double, double) ladosTri = (random.Next(0, 100), random.Next(0, 100), random.Next(0, 100));
                        nuevaFigura = new Triangulo(ladosTri.Item1, ladosTri.Item2, ladosTri.Item3);
                        break;

                    case eFormas2D.Rectangulo:
                        (double, double) ladosRect = (random.Next(0, 100), random.Next(0, 100));
                        nuevaFigura = new Rectangulo(ladosRect.Item1, ladosRect.Item2);
                        break;

                    case eFormas2D.Cuadrado:
                        double ladoCuad = random.Next(0, 100);
                        nuevaFigura = new Cuadrado(ladoCuad);
                        break;

                    case eFormas2D.Rombo:
                        (double, double) diagonalesRombo = (random.Next(0, 100), random.Next(0, 100));
                        nuevaFigura = new Rombo(diagonalesRombo.Item1, diagonalesRombo.Item2);
                        break;

                    case eFormas2D.NGono:
                        int numLados = random.Next(5, 12);  // Podría aumentar el numero de lados, pongo 12 de manera arbritaria
                        double ladoNGono = random.Next(0, 100);
                        nuevaFigura = new NGono(numLados, ladoNGono);
                        break;

                    default:
                        return;
                }

                figuras.Add(nuevaFigura);
            }
        }

        public double Area()
        {
            double area = 0;

            foreach (Figura2D figura in figuras)
                area += figura.Area();

            return area;
        }

        public double Perimetro()
        {
            double perimetro = 0;

            foreach (Figura2D figura in figuras)
                perimetro += figura.Perimetro();

            return perimetro;
        }

        public override string ToString()
        {
            string output = "";

            foreach(Figura2D figura2D in figuras)
            {
                output += figura2D.ToString() + ", ";
            }

            return output;
        }
    }
}
