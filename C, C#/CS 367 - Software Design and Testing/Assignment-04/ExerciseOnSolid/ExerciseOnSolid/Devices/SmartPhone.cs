using ExerciseOnSolid.Networks;

namespace ExerciseOnSolid.Devices
{
    public class SmartPhone : IPlaceCall, IPlaceVideoCall, ISendTextMessage, IBrowseInternet
    {
        public INetwork Network { get; init; }
        public NetworkStatus PlaceCall(string phoneNumber) => Network.PlaceCall(phoneNumber);
        public NetworkStatus PlaceVideoCall(string phoneNumber) => Network.PlaceVideoCall(phoneNumber);
        public NetworkStatus SendTextMessage(string phoneNumber, string message) => Network.SendTextMessage(phoneNumber, message);
        public NetworkStatus BrowseInternet(string url) => Network.BrowseInternet(url);
        public string PhoneNumber => Network.DevicePhoneNumber;
    }
}