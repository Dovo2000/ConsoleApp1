using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Doctor : Person
    {
        List<Patient> patients;
        string speciality;
        List<Appointment> appointments;

        public Doctor(string name, int age, string speciality) : base(name, age)
        {
            patients = new List<Patient>();
            this.speciality = speciality;
            appointments = new List<Appointment>();
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += "Patients: \n";

            foreach (Patient patient in patients) 
                output += patient.ToString() + "\n";

            return output;
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }

        public void RemovePatient(int patientId)
        {
            try
            {
                Patient patient = patients.Find(p => p.Id == patientId);
                patients.Remove(patient);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool HasPatient(int patientId) 
        {
            try
            {
                Patient patient = patients.Find(p => p.Id == patientId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public void RemoveAppointment(Appointment appointmentToRemove)
        {
            appointments.Remove(appointmentToRemove);
        }
    }
}
