using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOnSolid.Networks
{
    public interface INetwork
    {
        public string CarrierName { get; init; }
        public string DevicePhoneNumber { get; init; }

        public NetworkStatus PlaceCall(string phoneNumber);
        public NetworkStatus PlaceVideoCall(string phoneNumber);
        public NetworkStatus SendTextMessage(string phoneNumber, string message);
        public NetworkStatus BrowseInternet(string url);
    }
}
