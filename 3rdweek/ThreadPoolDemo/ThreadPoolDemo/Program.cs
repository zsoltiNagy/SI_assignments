using System;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static public void ShowMyText(object state)
        {
            string txt = "State: " + (string)state;
            txt += " Thread: " + Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(txt);
        }

        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(ShowMyText);
            ThreadPool.QueueUserWorkItem(callback, "Hello");
            ThreadPool.QueueUserWorkItem(callback, "Hi");
            ThreadPool.QueueUserWorkItem(callback, "Heya");
            ThreadPool.QueueUserWorkItem(callback, "Goodbye");
            Console.ReadKey();
        }
    }
}