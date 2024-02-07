using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstrasAlgorithm.GraphAdt
{
    public class Graph<TV, TE> : IGraph<TV, TE>
    {
        private readonly IList<IVertex<TV, TE>> _verticies = new List<IVertex<TV, TE>>();
        public bool Empty => _verticies.Count == 0;
        public TV[] AllVertices 
        {
            get => _verticies.Select(v => v.Data).ToArray(); 
        }

        public TV[] Vertices(bool areProcessed) => _verticies.Where(vertex => vertex.Processed == areProcessed).Select(v => v.Data).ToArray();

        public TE[] Edges(TV vertexData) => _verticies.Single(vertex => vertex.Data.Equals(vertexData)).Edges;

        public void AddVertex(TV vertexData) =>
            _verticies.Add(new Vertex<TV, TE> { Data = vertexData, Processed = false });

        public void RemoveVertex(TV vertexData) 
        {
            throw new NotImplementedException();
        }
        public void AddEdge(TV origin, TV destination, TE edgeData, double weight)
        {
            var originExist = _verticies.SingleOrDefault(vertex => vertex.Data.Equals(origin));
            var destinationExist = _verticies.SingleOrDefault(vertex => vertex.Data.Equals(destination));

            if (originExist == null) AddVertex(origin);
            if (destinationExist == null) AddVertex(destination);

            var originVertex = _verticies.Single(vertex => vertex.Data.Equals(origin));
            var destinationVertex = _verticies.Single(vertex => vertex.Data.Equals(destination));

            originVertex.AddEdge(edgeData, destinationVertex, weight);
        }
        public void RemoveEdge(TV origin, TV destination, TE edgeData)
        {
            var originExist = _verticies.SingleOrDefault(vertex => vertex.Data.Equals(origin));
            var destinationExist = _verticies.SingleOrDefault(vertex => vertex.Data.Equals(destination));

            if (originExist == null) throw new Exception("The edge doesn't exist");
            if (destinationExist == null) throw new Exception("The edge doesn't exist");

            var originVertex = _verticies.Single(vertex => vertex.Data.Equals(origin));
            var destinationVertex = _verticies.Single(vertex => vertex.Data.Equals(destination));
            originVertex.RemoveEdge(edgeData, destinationVertex);
        }
        public TE Edge(TV origin, TV destination)
        {
            throw new NotImplementedException();
        }
        public void SetVertexProcessedState(TV vertexData, bool processed) => 
            _verticies.Single(vertexData => vertexData.Data.Equals(vertexData)).Processed = processed;
        public bool GetVertexProcessedState(TV vertexData) => 
            _verticies.Single(vertexData => vertexData.Data.Equals(vertexData)).Processed;
    }
}
