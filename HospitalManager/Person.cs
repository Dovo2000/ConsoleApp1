using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal abstract class Person
    {
        protected static int maxId = 0;
        protected string name;
        protected int age;


        public string Name { get => name; protected set => name = value; }

        public int Age { get => age; protected set => age = value; }

        public int Id;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;

            maxId++;
            this.Id = maxId;

        }

        public override string ToString()
        {
            return $"Name: {name}\nAge: {age}\nId: {id}\n";
        }
    }
}
