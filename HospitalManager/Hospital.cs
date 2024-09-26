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

        public void AddPatient(Patient patient, int doctorId)
        {
            try
            {
                people.Add(patient);

                Doctor doc = (Doctor) people.Find(d => d.Id == doctorId);
                patient.AssignedDoctor = doc;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The doctor assigned to that ID couldn't be found: {ex.Message}");
            }
        }

        public void RemovePatient(int patientId)
        {
            try
            {
                ((Patient) people.Find(d => d.Id == patientId)).AssignedDoctor = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The doctor or patient assigned to that ID couldn't be found: {ex.Message}");
            }
        }

        public override string ToString()
        {
            string output = "";
            output += "Doctors: \n";
            foreach (Person p in people)
            {
                if (p is Doctor)
                    output += p.ToString() + "\n";
            }

            output += "Administratives: \n";
            foreach (Person p in people)
            {
                if (p is Administrative)
                    output += p.ToString() + "\n";
            }

            output += "Patients: \n";
            foreach (Person p in people)
            {
                if (p is Patient)
                    output += p.ToString() + "\n";
            }

            return output;
        }

        public List<Doctor> GetDoctors()
        {
            return people.Where(p => p is Doctor).Cast<Doctor>().ToList();
        }

        public Doctor GetDoctorByID(int id)
        {
            return people.Find(p => p is Doctor &&  p.Id == id) as Doctor;
        }

        public List<Patient> GetPatients() 
        {
            return people.Where(p => p is Patient).Cast<Patient>().ToList(); ;
        }

        public Patient GetPatientByID(int id)
        {
            return people.Find(p => p is Patient && p.Id == id) as Patient;
        }
    }
}
