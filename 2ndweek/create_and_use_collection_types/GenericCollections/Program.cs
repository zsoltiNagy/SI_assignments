using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            dict[44] = "United Kingdom";
            dict[33] = "France";
            dict[31] = "Netherlands";
            dict[55] = "Brazil";
            //Console.WriteLine("The 33 Code is for: {0}", dict[33]);

            foreach (KeyValuePair<int, string> item in dict)
            {
                int code = item.Key;
                string country = item.Value;
                Console.WriteLine("The {0} Code is for: {1}", code, country);
            }

            Console.Read();
        }
    }
}
