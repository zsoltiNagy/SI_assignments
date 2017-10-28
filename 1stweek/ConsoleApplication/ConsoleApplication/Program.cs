using System;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace ConsoleApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var name_2 = "KrumpliJézus";
            Console.WriteLine($"Hello {name_2}!");
            Cat cat = new Lion();
                cat.MakeSound();
            int[] numbers = {5, 7, 6, 4, 23, 4, 3, 2, 2};
            var lowNums = numbers.Where(n => n > 5 && n < 8);
            Console.WriteLine(lowNums);
            Person Gazsi = new Person();
            Gazsi.Name = "Csabika";
            Console.WriteLine(Gazsi.Name);
            string original = Gazsi.Name;
            string capital = original.ToUpper();
            string lower = original.ToLower();
            string lower2 = "Another test".ToLower();
            
            string input = " Steve "; // has a space at the start and end.
            string clean1 = input.TrimStart(); // "Steve "
            string clean2 = input.TrimEnd(); // " Steve"
            string clean3 = input.Trim(); // "Steve"
            string shortversion = input.Trim().Substring(0,3); // "Ste"
            
            string name = "Steve";
            string greet1 = $"Hello {name}!"; // Hello Steve!
            string greet2 = "Hello " + name + "!"; // Hello Steve!
            string greet3 = String.Format("Hello {0}!", name); // Hello Steve!
            string greetTemplate = "Hello **NAME**!";
            string greet4 = greetTemplate.Replace("**NAME**", name); // Hello Steve!
            
            var currentTime = DateTime.Now; // current time
            var today = DateTime.Today; // current date - time is midnight
            var someDate = new DateTime(2016,7,1); // 1 July 2016, midnight
            var someMoment = new DateTime(2016,7,1,8,0,0); // 1 July 2016, 08:00.00
            var tomorrow = DateTime.Today.AddDays(1);
            var yesterday = DateTime.Today.AddDays(-1);
            var someDay = DateTime.Parse("7/1/2016");
            
            var someTime = new DateTime(2016,7,1,11,10,9); // 1 July 2016 11:10:09 AM
            int year = someTime.Year; // 2016
            int month = someTime.Month; // 7
            int day = someTime.Day; // 1
            int hour = someTime.Hour; // 11
            int minute = someTime.Minute; // 10
            int second = someTime.Second; // 9
        }
    }

    class Person
    {
        private String name;
        private int age;

        public String Name
        {
            set { name = value;
                Console.WriteLine($"Changed name to {name}" );
            }
            get { return name; }
        }

        public int Age
        {
            set { age = value; }
            get { return age; }
        }
    }

    public class Cat
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("purrr");
        }
    }

    public class Lion : Cat
    {
        public override void MakeSound()
        {
            Console.WriteLine("roar");
        }
    } 
    
    
}