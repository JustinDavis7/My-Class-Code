using HW2.Models;

namespace HW2.DAL.Abstract;

public interface IPeopleRepository
{
    /// <summary>
    /// Get the actor who has appeared in the most shows
    /// <summary>
    /// <returns> The actors name </returns>
    (string, int) HighestOccuranceActor();
}