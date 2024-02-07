using Coordinator.Lib.Interfaces;

namespace Coordinator.Lib
{
    public class MultilevelAggressiveScheduler : IScheduler
    {
        public IList<IJob> IoQueue { get; set; }

        public IJob PeakNext()
        {
            throw new NotImplementedException();
        }

        public void Reschedule(IJob job)
        {
            throw new NotImplementedException();
        }

        public void Schedule(IJob job)
        {
            throw new NotImplementedException();
        }

        public IJob TakeNext()
        {
            throw new NotImplementedException();
        }
    }
}
