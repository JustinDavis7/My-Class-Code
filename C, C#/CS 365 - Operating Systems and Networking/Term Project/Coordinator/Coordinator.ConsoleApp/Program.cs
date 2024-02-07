using Coordinator.Lib;

namespace Coordinator.ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        var coordinator = new Lib.Coordinator();

        coordinator.Run(args);
    }
}