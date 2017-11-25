using System;
using System.Collections.Generic;

namespace SerializePeople
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Person.PersonFactory(persons, 10);
            foreach (Person p in persons)
            {
                Console.WriteLine(p.ToString());
            }
            Person alfonz = new Person("Alfonz", Person.RandomDay(), Person.RandomGender());
            alfonz.Serialize();
            Person.Deserialize("Alfonz").ToString();
            Console.Read();

        }
    }
}
