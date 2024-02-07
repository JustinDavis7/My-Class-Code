using ExerciseOnSolid.Networks;

namespace ExerciseOnSolid.Devices
{
    public class ChildPhone : IPlaceCall
    {
        public INetwork Network { get; init; }
        public NetworkStatus PlaceCall(string phoneNumber) => Network.PlaceCall(phoneNumber);
        public string PhoneNumber => Network.DevicePhoneNumber;
    }
}