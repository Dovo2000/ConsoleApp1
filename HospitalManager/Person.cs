using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal abstract class Person
    {
        protected string name;
        protected int age;
        protected string id;

        public string Name { get => name; protected set => name = value; }

        public int Age { get => age; protected set => age = value; }

        public string Id { get => id; protected set => id = value; }

        public Person(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            this.id = id;
        }

        public override string ToString()
        {
            return $"Name: {name}\nAge: {age}\nId: {id}\n";
        }
    }
}
