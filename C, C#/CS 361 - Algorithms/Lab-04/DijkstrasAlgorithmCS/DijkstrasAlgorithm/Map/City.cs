using System;
using System.Collections.Generic;
using System.Text;

namespace DijkstrasAlgorithm.Map
{
    public class City
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var city = obj as City;
            //? says if the obj is null, don't try to call the property
            return Name.Equals(city?.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString() => Name;

    }
}
