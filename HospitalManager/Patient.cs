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

        public Patient(string name, int age, string id, string illness) : base(name, age, id)
        {
            Illness = illness;
        }

        public override string ToString()
        {
            return base.ToString() + "Illness: " + Illness + "\n";
        }
    }
}
