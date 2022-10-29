using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            Name = name;

            Age = age;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (age >= 0)
                {
                    age = value;
                }
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {name}, Age: {age}");
            return sb.ToString();
        }
    }
}
