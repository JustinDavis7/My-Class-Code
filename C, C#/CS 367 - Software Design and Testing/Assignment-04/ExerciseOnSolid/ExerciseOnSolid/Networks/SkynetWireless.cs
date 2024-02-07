using ExerciseOnSolid.Devices;
using System;

namespace ExerciseOnSolid.Networks
{
    public class SkynetWireless : INetwork
    {
        public string CarrierName { get; init;  }
        public string DevicePhoneNumber { get; init; }
        public NetworkStatus PlaceCall(string phoneNumber)
            => new Random().Next(10) == 5 ? NetworkStatus.OperationFail : NetworkStatus.OperationSucceed;

        public NetworkStatus PlaceVideoCall(string phoneNumber)
            => new Random().Next(5) == 3 ? NetworkStatus.OperationFail : NetworkStatus.OperationSucceed;

        public NetworkStatus SendTextMessage(string phoneNumber, string message)
            => new Random().Next(100) == 50 ? NetworkStatus.OperationFail : NetworkStatus.OperationSucceed;

        public NetworkStatus BrowseInternet(string url)
            => new Random().Next(50) == 25 ? NetworkStatus.OperationFail : NetworkStatus.OperationSucceed;
    }
}