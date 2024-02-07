using Coordinator.Lib.Interfaces;
using System.Collections;

namespace Coordinator.Lib
{
    public class JobQueue : IJobQueue
    {
        public Queue _queue = new Queue();
        public IJob Dequeue() => (IJob)_queue.Dequeue();

        public void Enqueue(IJob job) => _queue.Enqueue(job);
        public bool IsEmpty() => _queue.Count == 0;

        public IJob Peek() => (IJob)_queue.Peek();
    }
}
