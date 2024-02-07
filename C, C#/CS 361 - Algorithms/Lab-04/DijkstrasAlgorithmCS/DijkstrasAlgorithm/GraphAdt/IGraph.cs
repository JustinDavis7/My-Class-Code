namespace DijkstrasAlgorithm.GraphAdt
{
    public interface IGraph<TV, TE>
    {
        bool Empty { get; }
        TV[] AllVertices { get; }
        TV[] Vertices(bool areProcessed);
        TE[] Edges(TV vertexData);
        void AddVertex(TV vertexData);
        void RemoveVertex(TV vertexData);
        void AddEdge(TV origin, TV destination, TE edgeData, double weight);
        void RemoveEdge(TV origin, TV destination, TE edgeData);
        TE Edge(TV origin, TV destination);
        void SetVertexProcessedState(TV vertexData, bool processed);
        bool GetVertexProcessedState(TV vertexData);
    }
}
