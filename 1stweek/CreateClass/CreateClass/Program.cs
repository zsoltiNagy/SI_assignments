using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateClass
{
    internal class Program
    {   static List<Person> people = new List<Person>();

        public static void Main(string[] args)
        {
            CreatingPeople();
            Cloning();
        }
        
        private static void Cloning()
        {
            var Kovacs = new Employee("Géza", DateTime.Now, 1000, "léhűtő");
            Kovacs.Room.Number = 111;
            var Kovacs2 = (Employee)Kovacs.ShallowClone();
            Kovacs2.Room.Number = 112;
            Console.WriteLine(Kovacs.ToString());
            Console.WriteLine(Kovacs2.ToString());
            Console.ReadKey();
        }
    
        private static void CreatingPeople()
        {
            Person.PersonFactory(people, 10);
            Employee.EmployeeFactory(people, 10);
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
        
        
    }
}