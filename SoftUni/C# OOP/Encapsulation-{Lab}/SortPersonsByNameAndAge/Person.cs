using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private const decimal MINIMUM_WAGE = 650;

        private string firstName;

        private string lastName;

        private int age;

        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;

            LastName = lastName;

            Age = age;

            Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length >= 3)
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
            }
        }


        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length >= 3)
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }


        public int Age
        {
            get { return age; }
            private set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {

                    throw new ArgumentException($"Age cannot be zero or a negative integer!");
                }
            }
        }


        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value >= MINIMUM_WAGE)
                {
                    this.salary = value;
                }
                else
                {
                    throw new ArgumentException($"Salary cannot be less than {MINIMUM_WAGE} leva!");
                }

            }
        }


        public override string ToString()
        {
            string result = $"{FirstName} {LastName} receives {Salary:f2} leva.";

            return result;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.Salary += (Salary / 100) * (percentage / 2);
            }
            else
            {
                this.Salary += (Salary / 100) * percentage;
            }
        }



    }
}
