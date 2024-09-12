using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorDias
{
    internal class Program
    {
        enum eDiasSemana
        {
            Lunes = 1,
            Martes,
            Miercoles,
            Jueves,
            Viernes,
            Sabado,
            Domingo
        }

        static void Main(string[] args)
        {
            AskUser();
        }

        static void AskUser()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Introduce un día de la semana: ");
                string input = Console.ReadLine();

                bool parseSucceed = Enum.TryParse(input, true, out eDiasSemana dia);

                if (parseSucceed)
                {
                    Console.WriteLine($"El número del día de la semana es: {(int)dia}");
                }
                Console.ReadKey();
            }
        }
    }
}
