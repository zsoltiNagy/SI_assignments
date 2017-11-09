using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            do
            {
                var fileName = GetUserInputFileName();
                var path = GetUserInputPath();
                SearchFiles(fileName, path);
                Console.WriteLine("Press any key to continue or press 'x' to exit the program.");
                userInput = Console.ReadLine();
            } while (!userInput.Equals("x"));
        }

        static void SearchFiles(string fileName, string path)
        {
            try
            {
                string[] files = Directory.GetFiles(path, fileName, SearchOption.AllDirectories);
                var fileList = new List<string>(files);
                var fullNames = files.Select(file => new FileInfo(file).FullName).ToArray();
                PrintFileCount(fileList);
                PrintFileNames(files);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void PrintFileCount(List<string> files)
        {
            Console.WriteLine(string.Format("We found {0} files matching your parameters.", files.Count));
        }

        static void PrintFileNames(string[] files)
        {
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }

        static string GetUserInputFileName()
        {
            Console.WriteLine("Give me the name of the file:");
            string fileName = @"" + Console.ReadLine();
            fileName.TrimEnd('.');
            if (fileName.Split('.').Length < 2)
            {
                fileName = fileName + ".*";
            }
            return fileName;
        }

        static string GetUserInputPath()
        {
            Console.WriteLine("Give me the path to the directory:");
            return @"" + Console.ReadLine();
        }
    }
}
