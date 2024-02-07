using System;

namespace DijkstrasAlgorithm.GraphAdt
{
    public class Edge<TV, TE> : IEdge<TV, TE>
    {
        public double Weight { get; set; }
        public TE Data { get; set; }
        public IVertex<TV, TE> Destination { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Edge<TV, TE> edge)) return false;

            return Weight.Equals(edge?.Weight) && Data.Equals(edge.Data) && Destination.Equals(edge?.Destination);
        }

        public override string ToString() => $"{Data} - Destination : {Destination.ToString()}";

        public override int GetHashCode() => HashCode.Combine(Weight, Data, Destination);
    }
}