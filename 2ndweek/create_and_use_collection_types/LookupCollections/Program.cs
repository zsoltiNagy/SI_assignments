using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace LookupCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary listDictionary = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));

            listDictionary["Estados Unidos"] = "United States of America";
            listDictionary["Canadá"] = "Canada";
            listDictionary["España"] = "Spain";
            listDictionary["El Diablo"] = "The Devil";

            Console.WriteLine(listDictionary["españa"]);
            Console.WriteLine(listDictionary["CANADÁ"]);
            Console.Read();
        }
    }
}
