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
            Administrative admin = new Administrative("David", 23, "123456789A");
            Doctor doc = new Doctor("Jose", 43, "3463433G");
            Patient patient = new Patient("Antonio", 63, "76756732H");

            Console.WriteLine(admin.ToString());
            Console.WriteLine(doc.ToString());
            Console.WriteLine(patient.ToString());
            Console.ReadKey();
        }
    }
}
