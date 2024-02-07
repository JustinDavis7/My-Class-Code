using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AmusementPark.New
{
    public class FoodieCart
    {
        private static object _serviceEndTimeLock = new();
        private static DateTime ServiceTimeEnd;

        private static int _lengthOfTimeToRun;
        private static int _numberWorkers;
        private static int _timeBetweenCustomers;
        private static int _averageServiceTime;

        private static readonly BlockingCollection<Thread> Line = new();

        private static Semaphore Workers;

        private static DateTime StartTime = DateTime.Now;

        private static TimeSpan WaitTime = new TimeSpan();
        public int CustomerCount = 0;

        private static TimeSpan ts;
        private static TimeSpan TimeSpanTempHolder;

        private static Dictionary<int, DateTime> LineEntryTimes = new();

        public FoodieCart(int numberWorkers , int timeBetweenCustomers, int averageServiceTime, int lengthOfTimeToRun)
        {
            _lengthOfTimeToRun = lengthOfTimeToRun;
            _numberWorkers = numberWorkers;
            _timeBetweenCustomers = timeBetweenCustomers;
            _averageServiceTime = averageServiceTime;

            Workers = new Semaphore(numberWorkers, numberWorkers);
        }

        private void QueueLine(object? obj)
        {
            DateTime runTime = StartTime;
            DateTime end = runTime.AddSeconds(_lengthOfTimeToRun);

            DateTime current = DateTime.Now;

            Random randomArrivalTime = new Random();
            DateTime addCustomer = current.AddSeconds(randomArrivalTime.Next(0, _timeBetweenCustomers * 2));

            var i = 0;

            while(runTime != end)
            {
                if (current == addCustomer) 
                {
                    ts = runTime - StartTime;
                    TimeSpanTempHolder = ts;

                    var guest = new Thread(GuestProcess)
                    {
                        Name = $"{++i}"              
                    };
                    
                    Console.WriteLine($"At time  {ts.TotalSeconds}, customer  {guest.Name} has entered the line");
                    LineEntryTimes.Add(Convert.ToInt32(guest.Name), DateTime.Now);

                    Line.Add(guest);

                    Thread.Sleep(2000);

                    current = DateTime.Now;
                    addCustomer = current.AddSeconds(randomArrivalTime.Next(0, _timeBetweenCustomers * 2));
                }
                current = current.AddSeconds(1);
                runTime = runTime.AddSeconds(1);
            }
            Console.WriteLine("\nLine is closed\n");
        }

        private void GuestProcess(object? obj)
        {
            CustomerCount++;

            Workers.WaitOne();

            DateTime serviceStart = DateTime.Now;

            Random randomServiceTime = new Random();

            var serviceTime = randomServiceTime.Next(0, _averageServiceTime * 2);

            DateTime serviceEnd = serviceStart.AddSeconds(serviceTime);

            ts = (DateTime.Now - StartTime).Add(TimeSpanTempHolder);

            Console.WriteLine($"At time  {Math.Ceiling(ts.TotalSeconds)}, customer  { Thread.CurrentThread.Name} being served!");
            WaitTime += DateTime.Now - LineEntryTimes[Convert.ToInt32(Thread.CurrentThread.Name)];
            
            Thread.Sleep(serviceTime * 1000);

            ts = (DateTime.Now - StartTime).Add(TimeSpanTempHolder);

            Console.WriteLine($"At time  {Math.Ceiling(ts.TotalSeconds)}, customer  { Thread.CurrentThread.Name} left the food cart.");

            lock (_serviceEndTimeLock)
            {
                ServiceTimeEnd = DateTime.Now.AddSeconds(serviceTime);
            }

            Workers.Release();
        }

        public void Run()
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
                if (guest.IsAlive) guest.Join();
            }

            while (DateTime.Now < (StartTime.AddSeconds(_lengthOfTimeToRun))) ;
            Console.WriteLine($"\n\nSimulation terminated after {CustomerCount} customers served.");
            Console.WriteLine($"Average waiting time {Math.Round(WaitTime.TotalSeconds/CustomerCount, 2)}");
        }
    }
}
