using System.Collections.Generic;

namespace DijkstrasAlgorithm.GraphAdt
{
    public interface IVertex<TV, TE>
    {
        TV Data { get; set; }
        TE[] Edges { get; }
        bool Processed { get; set; }
        void AddEdge(TE edgeData, IVertex<TV, TE> destinationVertex, double weight);
        void RemoveEdge(TE edgeData, IVertex<TV, TE> destinationVertex);
        TE Edge(TV destination);
    }
}