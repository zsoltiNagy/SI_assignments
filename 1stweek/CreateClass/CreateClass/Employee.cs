using System.Collections.Generic;

namespace CreateClass
{
    public class Employee : Person
    {
        private int salary;
        private string profession;
        private Room roomNumber;

        
        public static List<Person> EmployeeFactory(List<Person> list, int count)
        {
            for (var step = 0; step < count; step++)
            {
                list.Add(new Employee());
            }
            return list;
        }
        
        protected Employee()
        {
            name = RandomName();
            birthDate = RandomDay();
            gender = RandomGender();
            salary = generator.Next(1000);
            profession = RandomProfession();
            roomNumber = new Room();
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
                   "\nRoom number: " + roomNumber.RoomNumber + "\n";
        }
    }
}