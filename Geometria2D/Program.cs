using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Figura2D> figuras2D = new List<Figura2D>();

            Circulo circulo1 = new Circulo(3);
            figuras2D.Add(circulo1);

            Circulo circulo2 = new Circulo(10);
            figuras2D.Add(circulo2);

            Elipse elipse1 = new Elipse(5, 7);
            figuras2D.Add(elipse1);

            Rectangulo rect1 = new Rectangulo(7, 10);
            figuras2D.Add(rect1);

            Cuadrado cuadrado1 = new Cuadrado(10);
            figuras2D.Add(cuadrado1);

            NGono nGono1 = new NGono(7, 10);
            figuras2D.Add(nGono1);

            NGono nGono2 = new NGono(5, 5);
            figuras2D.Add(nGono2);


            foreach (Figura2D figura2D in figuras2D)
                Console.WriteLine($"{figura2D.ToString()} - | Perímetro: {figura2D.Perimetro()} | Área: {figura2D.Area()}");

            Console.ReadKey();
        }
    }
}
