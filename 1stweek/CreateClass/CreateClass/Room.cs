using System;

namespace CreateClass
{
    public class Room
    {
        static Random generator = new Random();
        private int number;

        public Room()
        {
            number = generator.Next(100);
        }
        
        public int Number
        {
            get => number;
            set => number = value;
        }
    }
}