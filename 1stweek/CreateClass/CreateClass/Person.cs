using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.SqlServer.Server;

namespace CreateClass
{
    public class Person
    {
        private string name;
        private DateTime birthDate;
        private Genders gender;
        static Random generator = new Random();

        public static List<Person> PersonFactory(List<Person> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(new Person(RandomName(), RandomDay(), RandomGender()));
            }
            return list;
        }

        private Person(string name, DateTime birthDate, Genders gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
        }

        private static string RandomName()
        {
            return Path.GetRandomFileName().Replace(".", string.Empty);
        }
        
        private static Genders RandomGender()
        {
            return generator.Next(100) < 50 ? Genders.Female : Genders.Male;
        }

        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
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