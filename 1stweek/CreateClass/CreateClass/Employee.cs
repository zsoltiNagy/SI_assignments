using System;
using System.Collections.Generic;

namespace CreateClass
{
    public class Employee : Person, ICloneable 
    {
        private int salary;
        private string profession;
        public Room Room;
        
        public object ShallowClone()
        {
            return MemberwiseClone();
        }

        public object Clone()
        {
            var newEmployee = (Employee) MemberwiseClone();
            //newEmployee.Room = new Room();
            return newEmployee;
        }
        
        public static List<Person> EmployeeFactory(List<Person> list, int count)
        {
            for (var step = 0; step < count; step++)
            {
                list.Add(new Employee());
            }
            return list;
        }
        
        private Employee()
        {
            name = RandomName();
            birthDate = RandomDay();
            gender = RandomGender();
            salary = generator.Next(1000);
            profession = RandomProfession();
            Room = new Room();
        }

        public Employee(string name, DateTime birthDate, int salary, string profession)
        {
            this.name = name;
            this.birthDate = birthDate;
            gender = RandomGender();
            this.salary = salary;
            this.profession = profession;
            Room = new Room();
        }

        private static string RandomProfession()
        {
            return RandomName() + "ist";
        }
        
        public override string ToString()
        {
            return base.ToString() +
                   "Salary: " + salary +
                   "\nProfession: " + profession +
                   "\nRoom number: " + Room.Number + "\n";
        }
    }
}