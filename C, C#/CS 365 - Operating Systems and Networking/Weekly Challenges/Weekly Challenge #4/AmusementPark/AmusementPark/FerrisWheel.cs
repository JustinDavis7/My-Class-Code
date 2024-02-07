using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmusementPark
{
    public class FerrisWheel
    {
        private static object _loadEndTimeLock = new();

        private static readonly Mutex RideInMotion = new();
        private static readonly Semaphore Ride = new(5, 5);
        private static readonly BlockingCollection<Thread> Line = new();

        private static Mutex LoadEndTimeMutex = new();
        private static DateTime LoadTimeEnd;

        private const int MaxLoadTime = 5;

        private const int MaxRideTime = 5000;

        private static void QueueLine(object? obj)
        {
            var current = DateTime.Now;
            var end = current.AddSeconds(20);
            var i = 0;
            while (current < end)
            {
                var guest = new Thread(GuestProcess)
                {
                    Name = $"Thread {++i}"
                };

                Line.Add(guest);

                Thread.Sleep(2000);

                current = DateTime.Now;
            }

            Console.WriteLine("Line closed...");
        }

        private static void GuestProcess(object? obj)
        {
            Ride.WaitOne();

            while (DateTime.Now < LoadTimeEnd);

            Console.WriteLine($"{Thread.CurrentThread.Name} on the ride!");

            Thread.Sleep(MaxRideTime);

            //LoadEndTimeMutex.WaitOne();
            //LoadTimeEnd = DateTime.Now.AddSeconds(MaxLoadTime);
            //LoadEndTimeMutex.ReleaseMutex();

            // ^ OR v  These do the same thing but the lower is new and a little easier to do.

            lock (_loadEndTimeLock)
            {
                LoadTimeEnd = DateTime.Now.AddSeconds(MaxLoadTime);
            }

            Ride.Release();

        }

        public static void Main2(string[] args)
        {
            var lineThread = new Thread(QueueLine);
            lineThread.Start();

            var current = DateTime.Now;
            var end = current.AddSeconds(25);

            while (current < end)
            {
                Line.TryTake(out var guest);
                guest?.Start();
                
                current = DateTime.Now;
            }

            foreach (var guest in Line)
            {
                if(guest.IsAlive) guest.Join();
            }

            Console.WriteLine("Game over");
        }
    }
}
