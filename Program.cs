/* Author:Seth McCrudden
* Last date modified: 27-Oct-2020
* File name: Program.cs
* Description: Holds main function
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            const int sleepBetweenThreads = 16;

            Console.Write("Number of throws per thread: ");
            int throwsCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of threads: ");
            int threadCount = Convert.ToInt32(Console.ReadLine());

            List<Thread> threads = new List<Thread>(threadCount);
            List<FindPiThread> findPiThreads = new List<FindPiThread>(threadCount);

            var stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < threadCount; i++)
            {
                findPiThreads.Add(new FindPiThread(throwsCount));
                threads.Add(new Thread(new ThreadStart(findPiThreads[i].throwDarts)));
                threads[i].Start();
                Thread.Sleep(sleepBetweenThreads);
            }

            for (int i = 0; i < threadCount; i++)
            {
                threads[i].Join();
            }

            long dartsInCircle = 0;
            long dartsThrown = (long)throwsCount * threadCount;

            for (int i = 0; i < threadCount; i++)
            {
                dartsInCircle += findPiThreads[i].dartsInCircle;
            }

            double PI = (double)(4 * dartsInCircle) / dartsThrown;

            stopWatch.Stop();

            Console.WriteLine("Took " + (stopWatch.ElapsedMilliseconds - sleepBetweenThreads * threadCount) + " ms");
            Console.WriteLine("Total Darts Inside Circle: " + dartsInCircle);
            Console.WriteLine("Total Darts Thrown: " + dartsThrown);
            Console.WriteLine("PI: " + PI);

            Console.ReadKey();
        }
    }
}
