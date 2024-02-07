using HW6.Models;

namespace HW6.DAL.Abstract
{
    public interface IStaskRepository : IRepository<Stask>
    {
        /// <summary>
        /// Return all active tasks that will occur or re-occur between today and today + days.
        /// We do not count hours, minutes or seconds, just whole days starting from today.
        /// </summary>
        /// <param name="today">The date to start the time window</param>
        /// <param name="days">The length of the time window in days</param>
        /// <returns>A list of tasks todo within the time window, ordered chronologically by calculated date</returns>
        List<TaskTodo> GetAllTasksTodoWithinTimeWindow(DateOnly today, int days);

        // DateOnly (and TimeOnly) are VERY welcome additions to the C# standard library as of .NET 6
        // See: https://learn.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-6.0
    }
}
