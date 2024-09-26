using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Appointment
    {
        public DateTime DateTime;
        public string Notes;

        public Appointment(DateTime dateTime, string notes = "") 
        {
            DateTime = dateTime;
            Notes = notes;
        }

        public override string ToString()
        {
            return $"Date: {DateTime.ToString()}\nNotes: {Notes}";
        }
    }
}
