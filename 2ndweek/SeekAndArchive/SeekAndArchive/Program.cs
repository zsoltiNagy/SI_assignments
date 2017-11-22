using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;

namespace SeekAndArchive
{
    class Program
    {
        static List<FileInfo> FoundFiles;
        static List<FileSystemWatcher> watchers;
        static List<DirectoryInfo> archiveDirs;

        static void Main(string[] args)
        {
            string fileName = GetUserInputFileName();
            DirectoryInfo rootDir = GetUserInputRootDirectory();
            FoundFiles = new List<FileInfo>();
            watchers = new List<FileSystemWatcher>();

            if (rootDir == null)
            {
                return;
            }

            if (!rootDir.Exists)
            {
                Console.WriteLine("The specified directory does not exist.");
                Console.WriteLine("Try something like: " + Environment.CurrentDirectory);
                return;
            }

            RecursiveSearch(FoundFiles, fileName, rootDir);
            Console.WriteLine("\nFound {0} files.", FoundFiles.Count);
            foreach (FileInfo fil in FoundFiles)
            {
                Console.WriteLine("{0}", fil.FullName);
                FileSystemWatcher watcher = new FileSystemWatcher(fil.DirectoryName, fil.Name);
                watcher.Changed += File_Changed;
                watcher.Renamed += File_Renamed;
                watcher.Deleted += File_Deleted;
                watcher.EnableRaisingEvents = true;
                watchers.Add(watcher);
            }

            archiveDirs = new List<DirectoryInfo>();
            for (int i = 0; i < FoundFiles.Count; i++)
            {
                archiveDirs.Add(Directory.CreateDirectory("archive" + i.ToString()));
            }

            while (true)
            {
                Console.ReadKey();
            }
        }

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo fil in currentDirectory.GetFiles(fileName))
            {
                foundFiles.Add(fil);
            }

            foreach ( DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                try
                {
                    RecursiveSearch(foundFiles, fileName, dir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static string GetUserInputFileName()
        {
            Console.WriteLine("Give me the name of the file:");
            string fileName = @"" + Console.ReadLine();
            if (fileName.Length < 1)
            {
                fileName = "*.*";
            }
            fileName.TrimEnd('.');

            if (!fileName.Contains('.') || fileName.Split('.').Length < 2)
            {
                fileName = fileName + ".*";
            }
            return fileName;
        }

        static DirectoryInfo GetUserInputRootDirectory()
        {
            Console.WriteLine("Give me the name of the root directory:");
            try
            {
                return new DirectoryInfo(@"" + Console.ReadLine());
            } catch (ArgumentException e)
            {
                Console.WriteLine(e.Message + " An empty string is not enough.");
            }
            return null;
        }

        static void ArchiveFile(DirectoryInfo archiveDir, FileInfo fileToArchive)
        {
            // Function tries to open the file, in case of IOException it tries it again after a second
            Boolean knockKnock = true;
            while (knockKnock)
            {
                try
                {
                    fileToArchive.OpenRead();
                    knockKnock = false;
                    break;
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(1000);
                }
            }
            FileStream input = fileToArchive.OpenRead();
            FileStream output = File.Create(archiveDir.FullName + @"\" + fileToArchive.Name + ".gz");
            GZipStream Compressor = new GZipStream(output, CompressionMode.Compress);
            int b = input.ReadByte();
            while ( b!= -1)
            {
                Compressor.WriteByte((byte)b);
                b = input.ReadByte();
            }
            Compressor.Close();
            input.Close();
            output.Close();
        }

        static void File_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} {1}", e.FullPath, e.ChangeType);
            CallArchiveFile(sender);
        }

        static void File_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} {1}", e.FullPath, e.ChangeType);
            //We should also delete it from the list
        }

        static void File_Renamed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} {1}", e.FullPath, e.ChangeType);
        }

        static void CallArchiveFile(object sender)
        {
            FileSystemWatcher senderWatcher = (FileSystemWatcher)sender;
            int index = watchers.IndexOf(senderWatcher, 0);
            ArchiveFile(archiveDirs[index], FoundFiles[index]);
        }

    }
}
