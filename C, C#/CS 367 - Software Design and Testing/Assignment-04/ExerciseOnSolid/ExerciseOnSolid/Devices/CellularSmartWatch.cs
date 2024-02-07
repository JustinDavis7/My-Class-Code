using ExerciseOnSolid.Networks;

namespace ExerciseOnSolid.Devices
{
    public class CellularSmartWatch : IPlaceCall, ISendTextMessage
    {
        public INetwork Network { get; init; }
        public NetworkStatus PlaceCall(string phoneNumber) => Network.PlaceCall(phoneNumber);

        public NetworkStatus SendTextMessage(string phoneNumber, string message) => Network.SendTextMessage(phoneNumber, message);

        public string PhoneNumber => Network.DevicePhoneNumber;
    }

}