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
        public Administrative(string name, int age) : base(name, age)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
