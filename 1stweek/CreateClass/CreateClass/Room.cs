using System;

namespace CreateClass
{
    public class Room
    {
        static Random generator = new Random();
        public int roomNumber;

        public Room()
        {
            roomNumber = generator.Next(100);
        }
        
        public int RoomNumber
        {
            get => roomNumber;
            set => roomNumber = value;
        }
    }
}