using Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();
        }


    }
}

//Administrative admin = new Administrative("David", 23, "123456789A");
//Doctor doc = new Doctor("Jose", 43, "3463433G");
//Doctor doc2 = new Doctor("Pepe", 26, "3463489J");
//Patient patient = new Patient("Antonio", 63, "76756732H", "COVID-19");
//Patient patient2 = new Patient("Jose Antonio", 50, "15115619F", "Gonorrea");
