using System;
using System.Collections.Generic;
using System.Text;

namespace DijkstrasAlgorithm.Map
{
    public class Highway
    {
        public string Name { get; set; }

        public double Distance { get; set; }

        public double AverageSpeedLimit { get; set; }

        public override bool Equals(object obj)
        {
            var highway = obj as Highway;
            //? says if the obj is null, don't try to call the property
            return Name.Equals(highway?.Name) &&
                Distance.Equals(highway?.Distance) &&
                AverageSpeedLimit.Equals(highway.AverageSpeedLimit);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Distance.GetHashCode() + AverageSpeedLimit.GetHashCode();
        }

        public override string ToString() => $"Name: {Name} Distance: {Distance} Average Speed Limit: {AverageSpeedLimit}";
    }
}
