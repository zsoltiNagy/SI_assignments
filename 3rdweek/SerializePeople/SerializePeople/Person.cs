using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SerializePeople
{
    [Serializable]
    public class Person : IDeserializationCallback, ISerializable
    {
        public enum Genders { Male, Female}
        public string name, fileName;
        public DateTime birthDate;
        public Genders gender;
        public static Random generator = new Random();
        [NonSerialized]
        public int age;
        public DateTime thisDay = DateTime.Today;

        public static List<Person> PersonFactory(List<Person> list, int count)
        {
            for (var step = 0; step < count; step++)
            {
                list.Add(new Person(RandomName(), RandomDay(), RandomGender()));
            }
            return list;
        }

        public Person()
        {
            name = RandomName();
            birthDate = RandomDay();
            gender = RandomGender();
            CalculateAge(birthDate);
            fileName = string.Format("{0}.bin", name);
        }

        public Person(string name, DateTime birthDate, Genders gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
            CalculateAge(birthDate);
            this.fileName = name + ".bin";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", name, typeof(string));
            info.AddValue("birthDate", birthDate, typeof(DateTime));
            info.AddValue("gender", gender, typeof(Genders));
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            name = (string)info.GetValue("name", typeof(string));
            birthDate = (DateTime)info.GetValue("birthDate", typeof(DateTime));
            gender = (Genders)info.GetValue("gender", typeof(Genders));
        }

        private void CalculateAge(DateTime birthDate)
        {
            DateTime currentDay = DateTime.Today;
            this.age = (currentDay - this.birthDate).Days / 365;
        }

        public static string RandomName()
        {
            return Path.GetRandomFileName().Replace(".", string.Empty);
        }

        public static Genders RandomGender()
        {
            return generator.Next(100) < 50 ? Genders.Female : Genders.Male;
        }

        public static DateTime RandomDay()
        {
            var start = new DateTime(2000, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(generator.Next(range));
        }

        public void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            
            using (Stream stream = new FileStream(fileName, 
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
        }

        public static Person Deserialize(string name)
        {
            Person person;
            string fileName = name + ".bin";
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName,
                FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                person = (Person)formatter.Deserialize(stream);
            }
            person.CalculateAge(person.birthDate);
            return person;

        }

        public void OnDeserialization(object sender)
        {
            string message = "Deserialization started";
            for (int i = 0; i< 4; i++)
            {
                Console.WriteLine(message);
                Thread.Sleep(100);
                message = ".";
            }
            Console.WriteLine("Deserialization finished");
        }


        public override string ToString()
        {
            return "Name: " + name +
                   "\nBirthdate: " + birthDate +
                   "\nGender: " + gender + "\n";
        }
    }
}