using ExerciseOnSolid.Networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOnSolid.Devices
{
    public interface IPlaceCall
    {
        NetworkStatus PlaceCall(string phoneNumber);
    }

    public interface ISendTextMessage
    {
        NetworkStatus SendTextMessage(string phoneNumber, string message);
    }

    public interface IPlaceVideoCall
    {
        NetworkStatus PlaceVideoCall(string phoneNumber);
    }

    public interface IBrowseInternet
    {
        NetworkStatus BrowseInternet(string url);
    }
}
