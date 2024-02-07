namespace AmusementPark;

public class MutexDemo
{
    private static readonly Mutex MutexLock = new();
    public void Run()
    {
        var mutexDemo = new MutexDemo();

        mutexDemo.GenerateThreads();
    }

    private void GenerateThreads()
    {
        for (var i = 0; i < 10; ++i)
        {
            var thread = new Thread(ThreadProcess)
            {
                Name = $"Thread {i + 1}"
            };
            thread.Start();
        }
    }

    private void ThreadProcess(object? obj)
    {
        MutexLock.WaitOne();

        Console.WriteLine($"{Thread.CurrentThread.Name} has entered the line.");
        
        Thread.Sleep(1000);
        
        Console.WriteLine($"{Thread.CurrentThread.Name} is done and leaving");
        
        MutexLock.ReleaseMutex();
    }
}