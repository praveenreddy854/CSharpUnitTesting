using System;
using System.Linq;

namespace MyConsoleApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.Write(p.GetPerson("John"));
        }

        public Person GetPerson(string name)
        {
            // Create person array
            Person[] people = new Person[2];

            people[0] = new Person(30, "John");
            people[1] = new Person(25, "Jane");

            return people.Where(p => p.Name == name).FirstOrDefault();
        }

        
    }

    public class Person
    {
        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public int Age { get; private set; }
        public string Name { get; private set; }
    }
}
