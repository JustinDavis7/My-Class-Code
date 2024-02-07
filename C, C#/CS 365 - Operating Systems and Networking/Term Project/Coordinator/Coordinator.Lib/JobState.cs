namespace Coordinator.Lib
{
    public enum JobState
    {
        New,
        Ready,
        Terminated,
        Running,
        Waiting,
        Preempted
    }
}
