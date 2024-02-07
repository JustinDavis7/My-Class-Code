namespace Coordinator.Lib.Interfaces
{
    public interface IJob : IComparable<IJob>
    {
        int PID { get; set; }
        int ArrivalTime { get; set; }
        int BurstTime { get; set; }
        int Priority { get; set; }
        JobState JobState { get; set; }
    }
}
