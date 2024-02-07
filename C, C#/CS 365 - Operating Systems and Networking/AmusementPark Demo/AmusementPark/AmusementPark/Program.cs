
using AmusementPark.New;
using System.Collections.Concurrent;

namespace AmusementPark
{
    public class FerrisWheelOriginal
    {
        private const int MaxGuests = 20;
        private const int MaxRideTime = 10;
        private const int RideWaitTimeToStart = 5;
        public static Random Random { get; set; } = new Random();
        public static double AverageWaitTime { get; set; } = 0;
        public static Mutex AverageWaitTimeMutex { get; set; } = new();
        public static Semaphore Ride { get; set; }
        public static BlockingCollection<Guest> Guests { get; set; } = new();
        public static int GuestNumber { get; set; } = 0;
        public static Mutex GuestNumberMutex { get; set; } = new();

        public static void GuestProcess(object param)
        {
            var arrivalTime = Convert.ToDateTime(param);
            Console.WriteLine($"Guest {Thread.GetCurrentProcessorId()} arrived at {arrivalTime}");

            var waitTime = (DateTime.Now - arrivalTime).Seconds;

            AverageWaitTimeMutex.WaitOne();
            AverageWaitTime += waitTime;
            AverageWaitTimeMutex.ReleaseMutex();

            Console.WriteLine($"Guest {Thread.GetCurrentProcessorId()} waited {waitTime}");
        }

        public static void QueueLine(object simulationTime)
        {
            var simulationEndTime = DateTime.Now.AddSeconds(Convert.ToInt32(simulationTime));

            while (DateTime.Now < simulationEndTime)
            {
                int guestNumber;

                GuestNumberMutex.WaitOne();
                guestNumber = ++GuestNumber;
                GuestNumberMutex.ReleaseMutex();

                var guest = new Guest
                {
                    ArrivalTime = DateTime.Now,
                    GuestNumber = guestNumber,
                    Thread = new Thread(new ParameterizedThreadStart(GuestProcess))
                };

                guest.Thread.Start();
                Guests.Add(guest);

                Console.WriteLine($"Guest number {Thread.GetCurrentProcessorId()} entered the line.");
            }
        }

        public static void LoadRide()
        {
            var numberOfGuests = 0;

            var timer = DateTime.Now;

            Console.WriteLine("Loading the ride with 20 guests.");

            while (numberOfGuests < Guests.Count &&
                   timer < timer.AddSeconds(RideWaitTimeToStart))
            {
                Ride.WaitOne();

                ++numberOfGuests;

                Ride.Release();
            }

            Console.WriteLine($@"Ride has been loaded.\Ride Starting with {numberOfGuests} guests");

            Thread.Sleep(MaxRideTime * 1000);

            Console.WriteLine("Ride is stopping.");
        }

        public static void Main2(string[] args)
        {
            //Console.WriteLine("Enter the simulation max run time: ");
            //var maxRunTime = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter the average time of arrival: ");
            //var averageArrivalTime = Convert.ToDouble(Console.ReadLine());

            //Ride = new Semaphore(MaxGuests, MaxGuests);

            //var queueingLineThread = new Thread(new ParameterizedThreadStart(QueueLine));
            //queueingLineThread.Start(maxRunTime);

            //var simulationEndTime = DateTime.Now.AddSeconds(Convert.ToInt32(maxRunTime));

            //while (DateTime.Now < simulationEndTime)
            //{
            //    LoadRide();
            //}

            //new MutexDemo().Run();
            //new SemaphoreDemo().Run();
        }
    }
}
