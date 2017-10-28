using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.SqlServer.Server;

namespace CreateClass
{
    public class Person
    {
        protected string name;
        protected DateTime birthDate;
        protected Genders gender;
        protected static Random generator = new Random();

        public static List<Person> PersonFactory(List<Person> list, int count)
        {
            for (var step = 0; step < count; step++)
            {
                list.Add(new Person(RandomName(), RandomDay(), RandomGender()));
            }
            return list;
        }

        protected Person()
        {
            name = RandomName();
            birthDate = RandomDay();
            gender = RandomGender();
        }
        
        private Person(string name, DateTime birthDate, Genders gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
        }

        protected static string RandomName()
        {
            return Path.GetRandomFileName().Replace(".", string.Empty);
        }
        
        protected static Genders RandomGender()
        {
            return generator.Next(100) < 50 ? Genders.Female : Genders.Male;
        }

        protected static DateTime RandomDay()
        {
            var start = new DateTime(2000, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(generator.Next(range));

        }
        
        public override string ToString()
        {
            return "Name: " + name +
                   "\nBirthdate: " + birthDate +
                   "\nGender: " + gender + "\n";
        }
    }
}