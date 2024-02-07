using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DijkstrasAlgorithm.GraphAdt
{
    public class Vertex<TV, TE> : IVertex<TV, TE>
    {
        private readonly IList<IEdge<TV, TE>> _edges = new List<IEdge<TV, TE>>();
        public TV Data { get; set; }

        //Select means I want a new list from the data, then convert that to an array.
        public TE[] Edges => _edges.Select(edge => edge.Data).ToArray();
        public bool Processed { get; set; }

        public void AddEdge(TE edgeData, IVertex<TV, TE> destinationVertex, double weight) 
            =>
            _edges.Add(new Edge<TV, TE> {Data = edgeData, Destination = destinationVertex, Weight = weight});

        public void RemoveEdge(TE edgeData, IVertex<TV, TE> destinationVertex)
        {
            var edgeToRemove = _edges.Single(edge => edge.Data.Equals(edgeData));
            _edges.Remove(edgeToRemove);
        }

        //This returns the data of the desired edge without return.
        public TE Edge(TV destination) => _edges.Single(edge => edge.Destination.Data.Equals(destination)).Data;

        public override bool Equals(object obj)
        {
            if (!(obj is IVertex<TV, TE> vertex)) return false;

            return _edges.Equals(vertex.Edges) && Data.Equals(vertex.Data) && Processed.Equals(vertex.Processed);
        }

        public override string ToString() => Data.ToString();
    }
}