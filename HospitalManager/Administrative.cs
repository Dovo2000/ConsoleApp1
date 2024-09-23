using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Administrative : Person
    {
        public Administrative(string name, int age, string id) : base(name, age, id)
        {
        }

        public override string ToString()
        {
            return base.ToString() + GetType().ToString();
        }
    }
}
