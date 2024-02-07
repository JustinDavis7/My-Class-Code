namespace Coordinator.Lib.Interfaces
{
    public interface IJobQueue
    {
        void Enqueue(IJob job);
        IJob Dequeue();
        IJob Peek();
        bool IsEmpty();
    }
}
