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
            Hospital hospital = new Hospital();

            Administrative admin = new Administrative("David", 23, "123456789A");
            Doctor doc = new Doctor("Jose", 43, "3463433G");
            Doctor doc2 = new Doctor("Pepe", 26, "3463489J");
            Patient patient = new Patient("Antonio", 63, "76756732H", "COVID-19");
            Patient patient2 = new Patient("Jose Antonio", 50, "15115619F", "Gonorrea");

            hospital.AddDoctor(doc);
            hospital.AddDoctor(doc2);
            hospital.AddAdministrative(admin);
            hospital.AddPatient(patient, doc.Id);
            hospital.RemovePatient(patient, doc.Id);
            hospital.AddPatient(patient, doc2.Id);
            hospital.AddPatient(patient2, doc.Id);

            Console.WriteLine(hospital.ToString());
            Console.ReadKey();
        }


    }
}
