namespace AmusementPark;

public class SemaphoreDemo
{
    private static readonly Semaphore CountingSemaphore = new(5, 5);
    public void Run()
    {
        for (var i = 0; i < 50; ++i)
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
        try
        {
            CountingSemaphore.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the line.");

            Thread.Sleep(5000);

            Console.WriteLine($"{Thread.CurrentThread.Name} is done and leaving");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            CountingSemaphore.Release();
        }

    }
}