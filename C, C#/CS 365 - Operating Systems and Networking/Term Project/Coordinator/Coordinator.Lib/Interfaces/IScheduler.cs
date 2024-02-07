namespace Coordinator.Lib.Interfaces
{
    public interface IScheduler
    {
        IList<IJob> IoQueue { get; set; }
        void Schedule(IJob job);
        void Reschedule(IJob job);
        IJob TakeNext();
        IJob PeakNext();
    }
}
