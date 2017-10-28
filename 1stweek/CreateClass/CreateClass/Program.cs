using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateClass
{
    internal class Program
    {
        static List<Person> people = new List<Person>();
        public static void Main(string[] args)
        {
            Person.PersonFactory(people, 10);
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}