using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Patient : Person
    {
        public string Illness;
        private Doctor doctor;

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

        public Patient(string name, int age, string id) : base(name, age, id)
        {

        }

        public Patient(string name, int age, string id, string illness, Doctor doctor) : base(name, age, id)
        {
            Illness = illness;
            this.doctor = doctor;
        }

        public override string ToString()
        {
            return base.ToString() + "Illness: " + Illness + "\n";
        }
    }
}
