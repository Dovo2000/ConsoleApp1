using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Patient : Person
    {
        public string Illness;
        public string PhoneNumber;
        private Doctor doctor;
        private List<Appointment> appointments;

        public Doctor AssignedDoctor { 
            get 
            { 
                return doctor;
            }
            set
            {
                if (doctor != null)
                    doctor.RemovePatient(this.Id);

                doctor = value;
                doctor.AddPatient(this);
            }
        }

        public Patient(string name, int age) : base(name, age)
        {
            appointments = new List<Appointment>();
        }

        public Patient(string name, int age, string illness, string phoneNumber) : this(name, age)
        {
            Illness = illness;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{base.ToString()}Illness: {Illness}\nDoctor: {doctor.Name}\nAppointments: {AppointmentsToString()}";
        }

        public void AddAppointment(Appointment newAppointment)
        {
            appointments.Add(newAppointment);
            doctor.AddAppointment(newAppointment);
        }

        public void ModifyAppointment(Appointment lastAppointment, Appointment newAppointment)
        {
            RemoveAppointment(lastAppointment);
            AddAppointment(newAppointment);
        }

        public void RemoveAppointment(Appointment appointmentToRemove)
        {
            doctor.RemoveAppointment(appointmentToRemove);
            appointments.Remove(appointmentToRemove);
        }

        public string AppointmentsToString()
        {
            string result = "";

            foreach (Appointment appointment in appointments)
            {
                result += appointment.ToString();
            }

            return result ;
        }
    }
}
