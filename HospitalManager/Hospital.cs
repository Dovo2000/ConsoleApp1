using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Hospital
    {
        List<Person> people;

        public Hospital() 
        {
            people = new List<Person>();
        }

        public void AddDoctor(Doctor doctor)
        {
            people.Add(doctor);
        }

        public void RemoveDoctor(Doctor doctor) 
        { 
            people.Remove(doctor);
        }

        public void AddAdministrative(Administrative administrative) 
        { 
            people.Add(administrative);
        }

        public void RemoveAdministrative(Administrative administrative)
        {
            people.Remove(administrative);
        }

        public void AddPatient(Patient patient, Doctor doctor)
        {
            ((Doctor) people.Find(d => d == doctor)).AddPatient(patient);
        }

        public void RemovePatient(Patient patient, Doctor doctor)
        {
            ((Doctor) people.Find(d => d == doctor)).RemovePatient(patient);
        }

        public override string ToString()
        {
            string output = "";
            output += "Doctors: \n";
            foreach (Doctor doctor in people)
                output += doctor.ToString() + "\n";

            output += "Administratives: \n";
            foreach (Administrative admin in people)
                output += admin.ToString() + "\n";

            return output;
        }
    }
}
