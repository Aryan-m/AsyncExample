using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExample
{
    class Program
    {
        static void countTo3()
        {
            Task.Delay(1000);
        }
        static Task countTo3Async()
        {
            return new Task(() => Task.Delay(1000));
        }

        static async Task execAsync(Stopwatch timer)
        {
            timer.Start();
            await Task.WhenAll(new List<Task>
            {
                  countTo3Async()
                , countTo3Async()
                , countTo3Async()
            });
            timer.Stop();
        }

        static void Main(string[] args)
        {
            // set up timer
            var timer = new Stopwatch();

            // first do sync
            timer.Start();
            countTo3();
            countTo3();
            countTo3();
            timer.Stop();
            Console.WriteLine($"Sync: {timer.ElapsedMilliseconds}");

            // async
            timer.Reset();
            execAsync(timer);
            Console.WriteLine($"Async: {timer.ElapsedMilliseconds}");

        }
    }
}
