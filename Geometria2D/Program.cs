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
            ConsoleKeyInfo consoleKey;

            do
            {
                Console.Clear();
                Console.WriteLine("¿De cuantas figuras quieres el diagrama?");
                string input = Console.ReadLine();

                if(int.TryParse(input, out int diagramSize))
                {
                    Diagrama diagrama = new Diagrama(diagramSize);

                    Console.WriteLine($"El diagrama esta compuesto de {diagrama.ToString()}");
                    Console.WriteLine($"Área: {diagrama.Area()} | Perímetro: {diagrama.Perimetro()}");
                }
                else
                    Console.WriteLine("No se ha identificado correctamente el tamaño del diagrama");

                Console.WriteLine("Pulsa cualquier tecla para continuar o ESC para salir...");
                consoleKey = Console.ReadKey();
            }
            while (consoleKey.Key != ConsoleKey.Escape);
        }
    }
}
