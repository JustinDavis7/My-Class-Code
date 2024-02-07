using Coordinator.Lib.Interfaces;

namespace Coordinator.Lib
{
    public class PriorityJob : IJob
    {
        public int PID { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int Priority { get; set; }
        public JobState JobState { get; set; }

        public int ReadyTime = 0;
        public int WaitingTime = 0;
        public int RunningTime = 0;
        public int WorkingQuanta = 0;
        public int ElapsedTime = 0;

        public int CompareTo(IJob? job)
        { //If output is -1, then job1 is higher priority than job2 <----> job1.CompareTo(job2)
            return Priority.CompareTo(job?.Priority); //? means it can be null. And if it is, then it wont do the check so no error gets thrown.
        }

        public void UpdateTotalElapsedTime()
        {
            ElapsedTime = ReadyTime + WaitingTime + RunningTime;
        }
    }
}
