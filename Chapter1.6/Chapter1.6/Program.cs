using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chapter1._6
{
    class Program
    {
        // If you want to use local data in a thread and initialize it for each thread, 
        // you can use the ThreadLocal<T> class. 
        // This class takes a delegate to a method that initializes the value. 
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        static void Main()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() => 
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("THread B: {0}", x);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
